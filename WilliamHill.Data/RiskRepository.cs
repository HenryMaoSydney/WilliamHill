using System.Collections.Generic;
using System.Linq;
using WilliamHill.Data.Models;

namespace WilliamHill.Data
{
    public class RiskRepository : IRiskRepository
    {
        private IRiskDataContext _riskDataContext;
        public RiskRepository(IRiskDataContext riskDataContext)
        {
            _riskDataContext = riskDataContext;
        }

        public List<int> GetCustomers()
        {
            var settledCustomers = _riskDataContext.SettledBets.Select(s => s.CustomerId);
            var unsettledCustomers = _riskDataContext.UnsettledBets.Select(s => s.CustomerId);

            return settledCustomers.Union(unsettledCustomers).Distinct().ToList();
        }

        public List<SettledBet> GetSettledBets(int customerId)
        {
            return _riskDataContext.SettledBets.Where (s => s.CustomerId == customerId).ToList();
        }

        public List<UnsettledBet> GetUnSettledBets(int customerId)
        {
            return _riskDataContext.UnsettledBets.Where(s => s.CustomerId == customerId).ToList();
        }

        public List<UnsettledBet> GetAllUnSettledBets()
        {
            return _riskDataContext.UnsettledBets.ToList();
        }
    }
}