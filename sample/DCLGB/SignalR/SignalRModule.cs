using Autofac;
using Ding.Dependency;

namespace DCLGB.SignalR
{
    public class SignalRModule : Module, IConfig
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SignalRChatService>()
                .As<ISignalRChatService>()
                .InstancePerDependency();

            builder.AddSignalR();
        }
    }
}
