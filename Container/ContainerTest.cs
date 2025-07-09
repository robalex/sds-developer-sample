using System;
using System.Collections.Generic;
using Xunit;

namespace DeveloperSample.Container
{
    internal interface IContainerTestInterface
    {
    }

    internal class ContainerTestClass : IContainerTestInterface
    {
    }

    internal class SecondContainerTestClass : IContainerTestInterface
    {
    }

    public class ContainerTest
    {
        [Fact]
        public void CanBindAndGetService()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            var testInstance = container.Get<IContainerTestInterface>();
            Assert.IsType<ContainerTestClass>(testInstance);
        }

        [Fact]
        public void ImplementationNotBound()
        {
            var container = new Container();
            Assert.Throws<InvalidOperationException>(() => container.Get<IContainerTestInterface>());
        }

        [Fact]
        public void CannotDoubleBindInterface()
        {
            var container = new Container();
            container.Bind(typeof(IContainerTestInterface), typeof(ContainerTestClass));
            Assert.Throws<ArgumentException>(() => container.Bind(typeof(IContainerTestInterface), typeof(SecondContainerTestClass)));
        }

        [Fact]
        public void ImplementationDoesNotImplementInterface()
        {
            var container = new Container();
            Assert.Throws<ArgumentException>(() => container.Bind(typeof(IContainerTestInterface), typeof(List<string>)));
        }

        [Fact]
        public void InterfaceTypeCannotBeNull()
        {
            var container = new Container();
            Assert.Throws<ArgumentNullException>(() => container.Bind(null, typeof(ContainerTestClass)));
        }

        [Fact]
        public void ImplementationTypeCannotBeNull()
        {
            var container = new Container();
            Assert.Throws<ArgumentNullException>(() => container.Bind(typeof(IContainerTestInterface), null));
        }
    }
}