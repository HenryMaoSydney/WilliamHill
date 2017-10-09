using System.Collections.Generic;
using WilliamHill.Data.Models;

namespace WilliamHill.Data
{
    public interface IRiskRepository
    {
        IEnumerable<int> GetCustomers();
        IEnumerable<SettledBet> GetSettledBets(int customerId);
        IEnumerable<UnsettledBet> GetUnSettledBets(int customerId);
    }
}