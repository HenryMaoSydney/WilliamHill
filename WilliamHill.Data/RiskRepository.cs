using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public async Task<List<SettledBet>> GetSettledBets(int customerId)
        {
            return _riskDataContext.SettledBets.Where (s => s.CustomerId == customerId).ToList();
        }

        public async Task<List<UnsettledBet>> GetUnSettledBets(int customerId)
        {
            return _riskDataContext.UnsettledBets.Where(s => s.CustomerId == customerId).ToList();
        }

        public async Task<List<UnsettledBet>> GetAllUnSettledBets()
        {
            return _riskDataContext.UnsettledBets.ToList();
        }
    }
}