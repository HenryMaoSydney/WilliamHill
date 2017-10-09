using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.Data;
using WilliamHill.Data.Models;

namespace WilliamHill.RiskProfiler
{
    public class BetProfiler
    {
       
        public BetProfiler( )
        { 
        }


        public bool IsBetLargeSum(UnsettledBet bet)
        {
            return bet.ToWin >= 1000;
        }

        public bool IsHighlyUnusual(UnsettledBet bet, CustomerProfile customerProfile)
        {
            return bet.Stake >= customerProfile.AverageBet * 60;
        }

        public bool IsUnusual(UnsettledBet bet, CustomerProfile customerProfile)
        {
            return bet.Stake >= customerProfile.AverageBet * 10;
        }

        public bool IsRisk( CustomerProfile customerProfile)
        {
            return customerProfile.IsUpComingWiningAtUnusualRate;
        }
    }
}
