using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Jx_Commerce.SystemService;
using Jx_Commerce.Common.LogHelper;

namespace Jx_Commerce.CoreCommon.DependencyConfig
{
    public class SystemContainerConfigure : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogService>().As<ILogService>().SingleInstance();
            builder.RegisterType<Test>().As<ITest>().InstancePerDependency();
        }
    }
}
