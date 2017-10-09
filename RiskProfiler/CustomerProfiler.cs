using WilliamHill.Data;

namespace WilliamHill.RiskProfiler
{
    public class CustomerProfiler : ICustomerProfiler
    {
        private readonly IRiskRepository _riskRepository;

        public CustomerProfiler(IRiskRepository riskRepository)
        {
            _riskRepository = riskRepository;
        }

        public CustomerProfile GetProfiler(int customerId)
        {
            return new CustomerProfile(
                _riskRepository.GetSettledBets(customerId),
                _riskRepository.GetUnSettledBets(customerId)
            );
        }
    }
}