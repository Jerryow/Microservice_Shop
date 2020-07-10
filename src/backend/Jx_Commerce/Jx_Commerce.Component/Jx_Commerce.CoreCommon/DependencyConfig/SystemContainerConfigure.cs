using Autofac;
using Jx_Commerce.SystemService;
using Jx_Commerce.Common.LogHelper;
using Jx_Commerce.DataAccess.DapperAccess.DapperBase;
using Jx_Commerce.DataAccess.DapperAccess;

namespace Jx_Commerce.CoreCommon.DependencyConfig
{
    public class SystemContainerConfigure : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogService>().As<ILogService>().SingleInstance();
            builder.RegisterType<Test>().As<ITest>().InstancePerDependency();
            builder.RegisterGeneric(typeof(ExcuteDapperBase<>)).As(typeof(IExcuteDapper<>)).InstancePerDependency();
        }
    }
}
