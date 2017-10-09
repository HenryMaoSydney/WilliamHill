using System.Linq;
using WilliamHill.Data;

namespace WilliamHill.RiskProfiler
{
    public class CustomerProfiler
    {
        private readonly IRiskRepository _riskRepository;

        public CustomerProfiler(IRiskRepository riskRepository)
        {
            _riskRepository = riskRepository;
        }

        public bool IsWiningAtUnusualRate(int customerId)
        {
            var settledBets = _riskRepository.GetSettledBets(customerId).ToList();
            if (settledBets.Count == 0) return false;
            return settledBets.Count(bet => bet.Win > 0) * 100M / settledBets.Count() > 60;
        }

        public double GetAverageBet(int customerId)
        {
            var settledBets = _riskRepository.GetSettledBets(customerId).ToList();
            if (settledBets.Count == 0) return 0;
            return settledBets.Average(bet => bet.Stake);
        }
    }
}