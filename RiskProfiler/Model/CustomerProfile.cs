using System.Collections.Generic;
using System.Linq;
using WilliamHill.Data.Models;

namespace WilliamHill.RiskProfiler
{
    public class CustomerProfile
    { 
        public string Status {
            get
            {
                if (IsWiningAtUnusualRate) return "Unusual";
                return "Normal";
            }
        }

        public CustomerProfile(int customerId, bool isWiningAtUnusualRate, double averageBet, List<SettledBet> settledBets)
        {
            CustomerId = customerId;
            IsWiningAtUnusualRate = isWiningAtUnusualRate;
            AverageBet = averageBet;
            SettledBets = settledBets;
        }

        public int CustomerId { get; }
        public bool IsWiningAtUnusualRate { get; }
          
        public double AverageBet { get; }

        public List<SettledBet> SettledBets { get; }
    }
}