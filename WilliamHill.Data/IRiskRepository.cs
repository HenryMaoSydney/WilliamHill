using System.Collections.Generic;
using WilliamHill.Data.Models;

namespace WilliamHill.Data
{
    public interface IRiskRepository
    {
        List<int> GetCustomers();
        List<SettledBet> GetSettledBets(int customerId);
        List<UnsettledBet> GetUnSettledBets(int customerId);

        List<UnsettledBet> GetAllUnSettledBets();
    }
}