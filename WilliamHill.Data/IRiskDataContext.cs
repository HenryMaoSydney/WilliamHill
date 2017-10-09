using System.Collections.Generic;
using WilliamHill.Data.Models;

namespace WilliamHill.Data
{
    public interface IRiskDataContext
    {
          List<SettledBet> SettledBets { get; set; }
          List<UnsettledBet> UnsettledBets { get; set; } 
    }
}