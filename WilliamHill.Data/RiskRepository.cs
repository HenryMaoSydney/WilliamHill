using System.Collections.Generic;
using WilliamHill.Data.Models;

namespace WilliamHill.Data
{
    public class RiskRepository : IRiskRepository
    { 
        public List<int> GetCustomers()
        {
            return new List<int>();
        }

        public List<SettledBet> GetSettledBets()
        {
            return new List<SettledBet>();
        }

        public List<UnsettledBet> GetUnSettledBets()
        {
            return new List<UnsettledBet>();
        }
    }
}