using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WilliamHill.Data;
using WilliamHill.Data.Models;

namespace WilliamHill.UnitTest.Data
{ 

    [TestFixture]
    public class RiskRepositoryTester : TestBase
    {
        [TestCase]
        public void GetCustomerTest_Success()
        {
            Moq.Mock<IRiskDataContext>().Setup(ctx => ctx.SettledBets).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1},
                new SettledBet {CustomerId = 2}
            });
            Moq.Mock<IRiskDataContext>().Setup(ctx => ctx.UnsettledBets).Returns(new List<UnsettledBet>
            {
                new UnsettledBet {CustomerId = 1},
                new UnsettledBet {CustomerId = 3}
            });
            var rep = Moq.Create<RiskRepository>();

            var results = rep.GetCustomers();

            Assert.AreEqual(3, results.Count());
        }

        [TestCase]
        public void GetGetSettledBets_Success()
        {
            Moq.Mock<IRiskDataContext>().Setup(ctx => ctx.SettledBets).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake = 100, Win = 50},
                new SettledBet {CustomerId = 2, Stake = 200, Win = 0},
                new SettledBet {CustomerId = 1, Stake = 200, Win = 0}
            });
            var rep = Moq.Create<RiskRepository>();

            var results = rep.GetSettledBets(1);
            Assert.AreEqual(2, results.Count());


            results = rep.GetSettledBets(2);
            Assert.AreEqual(1, results.Count());
        }

        [TestCase]
        public void GetUnGetSettledBets_Success()
        {
            Moq.Mock<IRiskDataContext>().Setup(ctx => ctx.UnsettledBets).Returns(new List<UnsettledBet>
            {
                new UnsettledBet {CustomerId = 1, Stake = 100, ToWin = 50},
                new UnsettledBet {CustomerId = 2, Stake = 200, ToWin = 0},
                new UnsettledBet {CustomerId = 1, Stake = 200, ToWin = 0}
            });
            var rep = Moq.Create<RiskRepository>();

            var results = rep.GetUnSettledBets(1);
            Assert.AreEqual(2, results.Count());

            results = rep.GetUnSettledBets(2);
            Assert.AreEqual(1, results.Count());
        }
    }
}