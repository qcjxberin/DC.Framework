using Autofac;
using DCLGB.Data;
using DCLGB.Data.SqlServer;
using Ding.Datas.Dapper;
using Ding.Datas.Sql;
using Ding.Dependency;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DCLGB.Common
{
    public class ServiceModule : Module, IConfig
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<LGBUnitOfWork>()
                .As<ILGBUnitOfWork>()
                .InstancePerDependency();

            builder
                .RegisterType<SqlQuery>()
                .As<ISqlQuery>()
                .InstancePerDependency();

            builder.RegisterType<HostingEnvironment>().As<IHostingEnvironment>().SingleInstance();

            builder.Register<IConfiguration>(p =>
            {
                IHostingEnvironment env = p.Resolve<IHostingEnvironment>();
                var file = "appsettings.json";
                return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile(file, true, true)
                         .AddJsonFile($"{file.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[0]}.{env.EnvironmentName}.json", true)
                         .Build();
            }).SingleInstance();

            builder.AddDbContext<LGBUnitOfWork>((options, configuration) =>
            {
                string connectionString = configuration["ConnectionStrings:DefaultConnection"];
                options.UseSqlServer(connectionString);
            });
        }
    }
}
