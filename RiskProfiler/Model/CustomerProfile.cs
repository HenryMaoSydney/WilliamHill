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

        public CustomerProfile(int customerId, bool isWiningAtUnusualRate, double averageBet)
        {
            CustomerId = customerId;
            IsWiningAtUnusualRate = isWiningAtUnusualRate;
            AverageBet = averageBet;
        }

        public int CustomerId { get; }
        public bool IsWiningAtUnusualRate { get; }
          
        public double AverageBet { get; }
    }
}