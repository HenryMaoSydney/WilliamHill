using System.Collections.Generic;
using System.Threading.Tasks;
using WilliamHill.Data.Models;

namespace WilliamHill.Data
{
    public interface IRiskRepository
    {
          Task<List<SettledBet>> GetSettledBets(int customerId);
          Task<List<UnsettledBet>> GetUnSettledBets(int customerId);

          Task<List<UnsettledBet>> GetAllUnSettledBets();
    }
}