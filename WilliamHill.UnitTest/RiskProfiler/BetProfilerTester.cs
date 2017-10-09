using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using WilliamHill.Data;
using WilliamHill.Data.Models;
using WilliamHill.RiskProfiler;

namespace WilliamHill.UnitTest.RiskProfiler
{
    [TestFixture]
    internal class BetProfilerTester : TestBase
    {
        [TestCase]
        public void IsBetLargeSum_True()
        { 
            var betProfiler = Moq.Create<BetProfiler>(); 
            var results = betProfiler.IsBetLargeSum( new UnsettledBet( ) {ToWin = 1200});
            Assert.AreEqual(true, results);
        }

        [TestCase]
        public void IsBetLargeSum_False()
        { 
            var betProfiler = Moq.Create<BetProfiler>();
            var results = betProfiler.IsBetLargeSum(new UnsettledBet() { ToWin = 800 });
            Assert.AreEqual(false, results);
        }


        [TestCase]
        public void IsBetHighlUnusual_true()
        {

            var betProfiler = Moq.Create<BetProfiler>();
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 100},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 100}
            }); 
            var cp = Moq.Create<CustomerProfiler>(); 
            var customerProfile = cp.GetProfiler(1); 

            var results = betProfiler.IsHighlyUnusual(new UnsettledBet() { Stake = 2000 , ToWin = 800 }, customerProfile);

            Assert.AreEqual(20, customerProfile.AverageBet);
            Assert.AreEqual(true, results);
        }

        [TestCase]
        public void IsBetHighlUnusual_false()
        {

            var betProfiler = Moq.Create<BetProfiler>();
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake =  10 ,Win = 100},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  30 ,Win = 100}
            });
            var cp = Moq.Create<CustomerProfiler>();
            var customerProfile = cp.GetProfiler(1);

            var results = betProfiler.IsHighlyUnusual(new UnsettledBet() { Stake = 1000, ToWin = 800 }, customerProfile);

            Assert.AreEqual(20, customerProfile.AverageBet);
            Assert.AreEqual(false, results);
        }


        [TestCase]
        public void IsBetUnusual_true()
        {

            var betProfiler = Moq.Create<BetProfiler>();
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 100},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 100}
            });
            var cp = Moq.Create<CustomerProfiler>();
            var customerProfile = cp.GetProfiler(1);

            var results = betProfiler.IsUnusual(new UnsettledBet() { Stake = 300, ToWin = 800 }, customerProfile);

            Assert.AreEqual(20, customerProfile.AverageBet);
            Assert.AreEqual(true, results);
        }

        [TestCase]
        public void IsBetUnusual_false()
        {

            var betProfiler = Moq.Create<BetProfiler>();
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetSettledBets(1)).Returns(new List<SettledBet>
            {
                new SettledBet {CustomerId = 1, Stake =  10 ,Win = 100},
                new SettledBet {CustomerId = 1, Stake =  20 ,Win = 0},
                new SettledBet {CustomerId = 1, Stake =  30 ,Win = 100}
            });
            var cp = Moq.Create<CustomerProfiler>();
            var customerProfile = cp.GetProfiler(1);

            var results = betProfiler.IsHighlyUnusual(new UnsettledBet() { Stake = 100, ToWin = 800 }, customerProfile);

            Assert.AreEqual(20, customerProfile.AverageBet);
            Assert.AreEqual(false, results);
        }


        [TestCase]
        public void IsRisk_trus()
        {

            var betProfiler = Moq.Create<BetProfiler>(); 
            Moq.Mock<IRiskRepository>().Setup(ctx => ctx.GetUnSettledBets(1)).Returns(new List<UnsettledBet>
            {
                new UnsettledBet {CustomerId = 1, Stake =  10 ,ToWin = 100},
                new UnsettledBet {CustomerId = 1, Stake =  20 ,ToWin = 0},
                new UnsettledBet {CustomerId = 1, Stake =  30 ,ToWin = 100}
            });
            var cp = Moq.Create<CustomerProfiler>();
            var customerProfile = cp.GetProfiler(1);

            var results = betProfiler.IsRisk(  customerProfile);
             
            Assert.AreEqual(true, results);
        }
    }
}