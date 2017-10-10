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
            var results = betProfiler.GetProfile( new UnsettledBet( ) {ToWin = 1200}, new CustomerProfile( 1, false, 10, new List<SettledBet>() ));
            Assert.AreEqual(true, results.IsBetLargeSum);
        }

        [TestCase]
        public void IsBetLargeSum_False()
        { 
            var betProfiler = Moq.Create<BetProfiler>();
            var results = betProfiler.GetProfile(new UnsettledBet() { ToWin = 800 }, new CustomerProfile(1, false, 10, new List<SettledBet>()));
            Assert.AreEqual(false, results.IsBetLargeSum);
        }


        [TestCase]
        public void IsBetHighlUnusual_true()
        { 
            var betProfiler = Moq.Create<BetProfiler>(); 

            var results = betProfiler.GetProfile(new UnsettledBet() { Stake = 2000 }, new CustomerProfile(1, false, 20, new List<SettledBet>())); 
            Assert.AreEqual(true, results.IsHighlyUnusual);
        }

        [TestCase]
        public void IsBetHighlUnusual_false()
        { 
            var betProfiler = Moq.Create<BetProfiler>(); 
            var results = betProfiler.GetProfile(new UnsettledBet() { Stake = 1000 }, new CustomerProfile(1, false, 20, new List<SettledBet>())); 
            Assert.AreEqual(false, results.IsHighlyUnusual);
        }


        [TestCase]
        public void IsBetUnusual_true()
        {
            var betProfiler = Moq.Create<BetProfiler>();
            var results = betProfiler.GetProfile(new UnsettledBet() { Stake = 1000}, new CustomerProfile(1, false, 20, new List<SettledBet>()));
            Assert.AreEqual(true, results.IsUnusual);
        }

        [TestCase]
        public void IsBetUnusual_false()
        {

            var betProfiler = Moq.Create<BetProfiler>();
            var results = betProfiler.GetProfile(new UnsettledBet() { Stake = 100}, new CustomerProfile(1, false, 20, new List<SettledBet>()));
            Assert.AreEqual(false, results.IsUnusual);
        }


        [TestCase]
        public void IsRisk_true()
        {

            var betProfiler = Moq.Create<BetProfiler>();
            var results = betProfiler.GetProfile(new UnsettledBet() { Stake = 100 }, new CustomerProfile(1, true, 20, new List<SettledBet>()));
            Assert.AreEqual(true, results.IsRisk);
        }

        [TestCase]
        public void IsRisk_false()
        {

            var betProfiler = Moq.Create<BetProfiler>();
            var results = betProfiler.GetProfile(new UnsettledBet() { Stake = 100 }, new CustomerProfile(1, false, 20, new List<SettledBet>()));
            Assert.AreEqual(false, results.IsRisk);
        }
    }
}