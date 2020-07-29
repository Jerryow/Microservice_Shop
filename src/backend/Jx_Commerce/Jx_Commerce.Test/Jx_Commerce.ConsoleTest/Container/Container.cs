using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Jx_Commerce.ConsoleTest.Container.Base;
using Jx_Commerce.ConsoleTest.Aop.Extend;
using Jx_Commerce.DataAccess.DapperAccess;
using Jx_Commerce.DataAccess.DapperAccess.DapperBase;
using Microsoft.Extensions.Configuration;

namespace Jx_Commerce.ConsoleTest.Container
{
    public class Container
    {
        private static IContainer _container;

        public static T Resolve<T>()
        {
            return (T)_container.Resolve<T>();
        }

        public static void Register(IConfiguration configuration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<IConfiguration>().SingleInstance();//配置
            builder.RegisterGeneric(typeof(ExcuteDapperBase<>)).As(typeof(IExcuteDapper<>)).InstancePerDependency();
            builder.RegisterType<TestAop>().As<ITestAop>().SingleInstance();
            builder.RegisterType<System_UserService>().As<ISystem_UserService>().InstancePerDependency();
            builder.RegisterType<Test>().As<ITest>().SingleInstance();
            _container = builder.Build();
        }
    }
}
