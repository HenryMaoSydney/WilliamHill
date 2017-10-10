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
        public async Task IsWiningAtUnusualRate_True()
        {
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(Task.FromResult( new List <SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 100},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 100}
            } ) );
           
            var cp = Moq.Create<CustomerProfiler>();

            var results = await cp.GetProfile(1);

            Assert.AreEqual(true, results.IsWiningAtUnusualRate);
        }

        [TestCase]
        public async Task IsWiningAtUnusualRate_False()
        {
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(Task.FromResult(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 100}
            }));

            var cp = Moq.Create<CustomerProfiler>();

            var results = await cp.GetProfile(1);

            Assert.AreEqual(false, results.IsWiningAtUnusualRate);
        }

        [TestCase]
        public async Task IsWiningAtUnusualRate_FalseWhenNotFound()
        {
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(Task.FromResult( new List<SettledBet> () ));

            var cp = Moq.Create<CustomerProfiler>();

            var results = await cp.GetProfile(1);

            Assert.AreEqual(false, results.IsWiningAtUnusualRate);
        }

        [TestCase]
        public async Task GetAverageBet_Test()
        {
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(Task.FromResult( new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake =  10 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  30 ,Win = 100}
            } ) );

            var cp = Moq.Create<CustomerProfiler>();

            var results = await cp.GetProfile(1);

            Assert.AreEqual(20, results.AverageBet);
        }

        [TestCase]
        public async Task GetAverageBet_TestEmpty()
        {
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(Task.FromResult(new List<SettledBet>
            { 
            } ));

            var cp = Moq.Create<CustomerProfiler>();

            var results = await cp.GetProfile(1);

            Assert.AreEqual(0, results.AverageBet);
        }
    }
}
