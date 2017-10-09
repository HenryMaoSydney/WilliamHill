using Autofac.Extras.Moq;
using NUnit.Framework;

namespace WilliamHill.UnitTest
{
    public abstract class TestBase
    {
        protected AutoMock Moq;

        [SetUp]
        public void SetupAutomoq()
        {
            Moq = AutoMock.GetLoose();
        }
    }
}