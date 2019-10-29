using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AutofacTests.Interfaces;
using AutofacTests.Services;

namespace AutofacTests
{
    [TestClass]
    public class PropertyInjectionTests
    {
        private IContainer CreateContainer(Action<ContainerBuilder> customConfiguration = null)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NestedService>().As<INestedService>().PropertiesAutowired();
            builder.RegisterType<Service>().As<IService>().PropertiesAutowired();
            customConfiguration?.Invoke(builder);
            return builder.Build();
        }

        [TestMethod]
        public void PropertyInjectedServiceShouldNotBeNull()
        {
            var container = CreateContainer();

            var service = container.Resolve<IService>();

            Assert.IsTrue(service.NestedServiceIsNotNull());
        }

        [TestMethod]
        public void PropertyInjectedServiceShouldNotBeNullEvenIfDecoratorRegistered()
        {
            var container = CreateContainer(builder => builder.RegisterDecorator<ServiceDecorator, IService>());            

            var service = container.Resolve<IService>();

            Assert.IsTrue(service.NestedServiceIsNotNull());
        }
    }
}
