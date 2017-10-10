using System.Collections.Concurrent;
using System.Collections.Generic;
using WilliamHill.Data.Models;

namespace WilliamHill.Data
{
    public interface IRiskDataContext
    {
        ConcurrentBag<SettledBet> SettledBets { get; set; }
        ConcurrentBag<UnsettledBet> UnsettledBets { get; set; } 
    }
}