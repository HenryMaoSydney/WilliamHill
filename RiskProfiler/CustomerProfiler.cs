using System.Collections.Generic;
using System.Linq;
using WilliamHill.Data;
using WilliamHill.Data.Models;

namespace WilliamHill.RiskProfiler
{
    public class CustomerProfiler : ICustomerProfiler
    {
        private readonly IRiskRepository _riskRepository;

        public CustomerProfiler(IRiskRepository riskRepository)
        {
            _riskRepository = riskRepository;
        }

        public CustomerProfile GetProfile(int customerId)
        {
            var settledBet = _riskRepository.GetSettledBets(customerId);

            return new CustomerProfile(customerId, 
                CalculateWiningAtUnusualRate(settledBet),
                CalculateAverageBet(settledBet),
                settledBet); 
        }

        private bool CalculateWiningAtUnusualRate(IEnumerable<SettledBet> settledBets)
        { 
                if (!settledBets.Any()) return false;
                return settledBets.Count(bet => bet.Win > 0) * 100M / settledBets.Count() > 60; 
        }


        private double CalculateAverageBet(IEnumerable<SettledBet> settledBets)
        { 
                if (!settledBets.Any()) return 0;
                return settledBets.Average(bet => bet.Stake); 
        }
    }
}