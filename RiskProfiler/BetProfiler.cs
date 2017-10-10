using System;
using System.Globalization;
using System.Text;
using WilliamHill.Data.Models;

namespace WilliamHill.RiskProfiler
{
    public class BetProfiler : IBetProfiler
    {

        public BetProfile GetProfile(UnsettledBet bet, CustomerProfile customerProfile)
        { 
            return new BetProfile(CalculateIsBetLargeSum(bet),
                CalculateIsHighlyUnusual(bet, customerProfile),
                CalculateIsUnusual(bet, customerProfile),
                CalculateIsRisk(customerProfile));
        }


        private bool CalculateIsBetLargeSum(UnsettledBet bet)
        {
            return bet.ToWin >= 1000;
        }

        private bool CalculateIsHighlyUnusual(UnsettledBet bet, CustomerProfile customerProfile)
        {
            return bet.Stake >= customerProfile.AverageBet * 60;
        }

        private bool CalculateIsUnusual(UnsettledBet bet, CustomerProfile customerProfile)
        {
            return bet.Stake >= customerProfile.AverageBet * 10;
        }

        private bool CalculateIsRisk(CustomerProfile customerProfile)
        {
            return customerProfile.IsWiningAtUnusualRate;
        }
    }
}