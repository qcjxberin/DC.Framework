using Ding.TimedJob.Jobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Ding.TimedJob.Schema
{
    public class TimedJobService
    {
        private IAssemblyLocator Locator { get; set; }

        private IServiceProvider Services { get; set; }

        private IDynamicTimedJobProvider DynamicJobs { get; set; }

        private ILogger Logger { get; set; }

        public Dictionary<string, bool> JobStatus { get; private set; } = new Dictionary<string, bool>();

        public Dictionary<string, Timer> JobTimers { get; private set; } = new Dictionary<string, Timer>();

        private List<TypeInfo> JobTypeCollection { get; set; } = new List<TypeInfo>();

        public TimedJobService(IAssemblyLocator locator, IServiceProvider services)
        {
            this.Services = services;
            this.Locator = locator;
            this.Logger = services.GetService<ILogger>();
            this.DynamicJobs = services.GetService<IDynamicTimedJobProvider>();
            var asm = locator.GetAssemblies();
            foreach (var x in asm)
            {
                // 查找基类为Job的类
                var types = x.DefinedTypes.Where(y => y.BaseType == typeof(Job)).ToList();
                foreach (var y in types)
                {
                    JobTypeCollection.Add(y);
                }
            }
            StartHardTimers();
            if (DynamicJobs != null)
                StartDynamicTimers();
        }

        private void StartHardTimers()
        {
            foreach (var x in JobTypeCollection)
            {
                foreach (var y in x.DeclaredMethods)
                {
                    if (y.GetCustomAttribute<NonJobAttribute>() == null)
                    {
                        JobStatus.Add(x.FullName + '.' + y.Name, false);
                        var invoke = y.GetCustomAttribute<InvokeAttribute>();
                        if (invoke != null && invoke.IsEnabled)
                        {
                            long delta = 0;
                            if (invoke._begin == default)
                                invoke._begin = DateTime.Now;
                            else
                                delta = Convert.ToInt64((invoke._begin - DateTime.Now).TotalMilliseconds);
                            if (delta < 0)
                            {
                                delta %= Convert.ToInt64(invoke.Interval);
                                if (delta < 0)
                                    delta += Convert.ToInt64(invoke.Interval);
                            }

                            Task.Factory.StartNew(async () =>
                            {
                                if (delta > int.MaxValue)
                                {
                                    for (; delta > Int32.MaxValue; delta -= Int32.MaxValue)
                                    {
                                        await Task.Delay(Int32.MaxValue);
                                    }
                                }

                                var timer = new Timer(t => {
                                    Execute(x.FullName + '.' + y.Name);
                                }, null, Convert.ToInt32(delta), invoke.Interval);
                                JobTimers.Add(x.FullName + '.' + y.Name, timer);
                            });
                        }
                    }
                }
            }
        }

        private void StartDynamicTimers()
        {
            var jobs = DynamicJobs.GetJobs();
            foreach (var x in jobs)
            {
                // 如果Hard Timer已经启动则注销实例
                if (JobTimers.ContainsKey(x.Id))
                {
                    JobTimers[x.Id].Dispose();
                    JobStatus[x.Id] = false;
                    JobTimers.Remove(x.Id);
                    JobStatus.Remove(x.Id);
                }
                long delta = Convert.ToInt64((x.Begin - DateTime.Now).TotalMilliseconds);
                if (delta < 0)
                {
                    delta %= Convert.ToInt64(x.Interval);
                    if (delta < 0)
                        delta += Convert.ToInt64(x.Interval);
                }
                Task.Factory.StartNew(async () =>
                {
                    if (delta > int.MaxValue)
                    {
                        for (; delta > Int32.MaxValue; delta -= Int32.MaxValue)
                        {
                            await Task.Delay(Int32.MaxValue);
                        }
                    }
                    var timer = new Timer(t => {
                        Execute(x.Id);
                    }, null, Convert.ToInt32(delta), x.Interval);
                    JobTimers.Add(x.Id, timer);
                });
            }
        }

        public void RestartDynamicTimers()
        {
            var jobs = DynamicJobs.GetJobs();
            foreach (var x in jobs)
            {
                if (JobTimers.ContainsKey(x.Id))
                {
                    JobTimers[x.Id].Dispose();
                    JobStatus[x.Id] = false;
                    JobTimers.Remove(x.Id);
                    JobStatus.Remove(x.Id);
                }
            }
            StartDynamicTimers();
        }

        public bool Execute(string identifier)
        {
            var typename = identifier.Substring(0, identifier.LastIndexOf('.'));
            var function = identifier.Substring(identifier.LastIndexOf('.') + 1);
            var type = JobTypeCollection.SingleOrDefault(x => x.FullName == typename);

            if (type == null)
            {
                throw new NotImplementedException(typename + "." + function);
            }

            using (var serviceScope = Services.CreateScope())
            {
                var argtypes = type.GetConstructors()
                    .First()
                    .GetParameters()
                    .Select(x =>
                    {
                        if (x.ParameterType == typeof(IServiceProvider))
                            return serviceScope.ServiceProvider;
                        else
                            return serviceScope.ServiceProvider.GetService(x.ParameterType);
                    })
                    .ToArray();
                var job = Activator.CreateInstance(type.AsType(), argtypes);
                var method = type.GetMethod(function);
                var paramtypes = method.GetParameters().Select(x => serviceScope.ServiceProvider.GetService(x.ParameterType)).ToArray();
                var invokeAttr = method.GetCustomAttribute<InvokeAttribute>();
                lock (this)
                {
                    if (invokeAttr != null && invokeAttr.SkipWhileExecuting && JobStatus[identifier])
                        return false;
                    JobStatus[identifier] = true;
                }
                try
                {
                    if (Logger != null)
                        Logger.LogInformation("Invoking " + identifier + "...");
                    method.Invoke(job, paramtypes);
                }
                catch (Exception ex)
                {
                    if (Logger != null)
                        Logger.LogError(ex.ToString());
                }
                JobStatus[identifier] = false;
                return true;
            }
        }

        public List<string> GetJobFunctions()
        {
            var ret = new List<string>();
            foreach (var x in JobTypeCollection)
            {
                foreach (var y in x.DeclaredMethods)
                {
                    if (y.GetCustomAttribute<NonJobAttribute>() == null)
                    {
                        ret.Add(x.FullName + '.' + y.Name);
                    }
                }
            }
            return ret;
        }
    }
}
