using NUnit.Framework;
using WilliamHill.Data;

namespace WilliamHill.UnitTest.Data
{
    [TestFixture]
    public class RiskDataContectTester : TestBase
    {
        // Note this is not a strictly Unit Test. maybe move to system test later
        [TestCase]
        public void LoadTest_Success()
        {
            Moq.Mock<ISettlementFileLocator>().Setup(locator => locator.LocateSettleCsv).Returns(TestContext.CurrentContext.TestDirectory + "/Settled.csv");
            Moq.Mock<ISettlementFileLocator>().Setup(locator => locator.LocateUnSettleCsv).Returns(TestContext.CurrentContext.TestDirectory + "/UnSettled.csv");

            var sut = Moq.Create<RiskDataContext>();
            Assert.Greater(sut.SettledBets.Count, 0);
        }
    }
}