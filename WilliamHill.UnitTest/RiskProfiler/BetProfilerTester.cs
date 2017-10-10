using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task IsBetLargeSum_True()
        { 
            var betProfiler = Moq.Create<BetProfiler>(); 
            var results = await betProfiler.GetProfile( new UnsettledBet( ) {ToWin = 1200}, new CustomerProfile( 1, false, 10, new List<SettledBet>() ));
            Assert.AreEqual(true, results.IsBetLargeSum);
        }

        [TestCase]
        public async Task IsBetLargeSum_False()
        { 
            var betProfiler = Moq.Create<BetProfiler>();
            var results = await betProfiler.GetProfile(new UnsettledBet() { ToWin = 800 }, new CustomerProfile(1, false, 10, new List<SettledBet>()));
            Assert.AreEqual(false, results.IsBetLargeSum);
        }


        [TestCase]
        public async Task IsBetHighlUnusual_true()
        { 
            var betProfiler = Moq.Create<BetProfiler>(); 

            var results = await betProfiler.GetProfile(new UnsettledBet() { Stake = 2000 }, new CustomerProfile(1, false, 20, new List<SettledBet>())); 
            Assert.AreEqual(true, results.IsHighlyUnusual);
        }

        [TestCase]
        public async Task IsBetHighlUnusual_false()
        { 
            var betProfiler = Moq.Create<BetProfiler>(); 
            var results = await betProfiler.GetProfile(new UnsettledBet() { Stake = 1000 }, new CustomerProfile(1, false, 20, new List<SettledBet>())); 
            Assert.AreEqual(false, results.IsHighlyUnusual);
        }


        [TestCase]
        public async Task IsBetUnusual_true()
        {
            var betProfiler = Moq.Create<BetProfiler>();
            var results = await betProfiler.GetProfile(new UnsettledBet() { Stake = 1000}, new CustomerProfile(1, false, 20, new List<SettledBet>()));
            Assert.AreEqual(true, results.IsUnusual);
        }

        [TestCase]
        public async Task IsBetUnusual_false()
        {

            var betProfiler = Moq.Create<BetProfiler>();
            var results = await betProfiler.GetProfile(new UnsettledBet() { Stake = 100}, new CustomerProfile(1, false, 20, new List<SettledBet>()));
            Assert.AreEqual(false, results.IsUnusual);
        }


        [TestCase]
        public async Task IsRisk_true()
        {

            var betProfiler = Moq.Create<BetProfiler>();
            var results = await betProfiler.GetProfile(new UnsettledBet() { Stake = 100 }, new CustomerProfile(1, true, 20, new List<SettledBet>()));
            Assert.AreEqual(true, results.IsRisk);
        }

        [TestCase]
        public async Task IsRisk_false()
        {

            var betProfiler = Moq.Create<BetProfiler>();
            var results = await betProfiler.GetProfile(new UnsettledBet() { Stake = 100 }, new CustomerProfile(1, false, 20, new List<SettledBet>()));
            Assert.AreEqual(false, results.IsRisk);
        }
    }
}