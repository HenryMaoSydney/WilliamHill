using System.Collections.Generic;
using WilliamHill.Data.Models;

namespace WilliamHill.Data
{
    public interface IRiskRepository
    {
        List<int> GetCustomers();
        List<SettledBet> GetSettledBets();
        List<UnsettledBet> GetUnSettledBets();
    }
}