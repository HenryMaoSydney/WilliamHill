using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WilliamHill.Data;
using WilliamHill.Data.Models;
using WilliamHill.RiskProfiler;

namespace WilliamHill.UnitTest.RiskProfiler
{
    [TestFixture]
    class CustomerProfilerTester : TestBase
    {
        [TestCase]
        public void IsWiningAtUnusualRate_True()
        {
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 100},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 100}
            });
           
            var cp = Moq.Create<CustomerProfiler>();

            var results = cp.IsWiningAtUnusualRate(1);

            Assert.AreEqual(true, results);
        }

        [TestCase]
        public void IsWiningAtUnusualRate_False()
        {
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 100}
            });

            var cp = Moq.Create<CustomerProfiler>();

            var results = cp.IsWiningAtUnusualRate(1);

            Assert.AreEqual(false, results);
        }

        [TestCase]
        public void IsWiningAtUnusualRate_FalseWhenNotFound()
        {
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(new List<SettledBet> ());

            var cp = Moq.Create<CustomerProfiler>();

            var results = cp.IsWiningAtUnusualRate(1);

            Assert.AreEqual(false, results);
        }

        [TestCase]
        public void GetAverageBet_Test()
        {
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake =  10 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  30 ,Win = 100}
            });

            var cp = Moq.Create<CustomerProfiler>();

            var results = cp.GetAverageBet(1);

            Assert.AreEqual(20, results);
        }

        [TestCase]
        public void GetAverageBet_TestEmpty()
        {
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(new List<SettledBet>
            { 
            });

            var cp = Moq.Create<CustomerProfiler>();

            var results = cp.GetAverageBet(1);

            Assert.AreEqual(0, results);
        }
    }
}
