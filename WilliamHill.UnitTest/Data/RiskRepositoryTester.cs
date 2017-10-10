using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using WilliamHill.Data;
using WilliamHill.Data.Models;

namespace WilliamHill.UnitTest.Data
{ 

    [TestFixture]
    public class RiskRepositoryTester : TestBase
    {
      
        [TestCase]
        public async Task GetGetSettledBets_Success()
        {
            Moq.Mock<IRiskDataContext>().Setup(ctx => ctx.SettledBets).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake = 100, Win = 50},
                new SettledBet {CustomerId = 2, Stake = 200, Win = 0},
                new SettledBet {CustomerId = 1, Stake = 200, Win = 0}
            });
            var rep = Moq.Create<RiskRepository>();

            var results = await rep.GetSettledBets(1);
            Assert.AreEqual(2, results.Count());


            results = await rep.GetSettledBets(2);
            Assert.AreEqual(1, results.Count());
        }

        [TestCase]
        public async Task GetUnGetSettledBets_Success()
        {
            Moq.Mock<IRiskDataContext>().Setup(ctx => ctx.UnsettledBets).Returns(new List<UnsettledBet>
            {
                new UnsettledBet {CustomerId = 1, Stake = 100, ToWin = 50},
                new UnsettledBet {CustomerId = 2, Stake = 200, ToWin = 0},
                new UnsettledBet {CustomerId = 1, Stake = 200, ToWin = 0}
            });
            var rep = Moq.Create<RiskRepository>();

            var results = await rep.GetUnSettledBets(1);
            Assert.AreEqual(2, results.Count());

            results = await rep.GetUnSettledBets(2);
            Assert.AreEqual(1, results.Count());
        }
    }
}