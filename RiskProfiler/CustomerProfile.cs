using System.Collections.Generic;
using System.Linq;
using WilliamHill.Data.Models;

namespace WilliamHill.RiskProfiler
{
    public class CustomerProfile
    {

        private readonly IEnumerable<SettledBet> _settledBets;
        private readonly IEnumerable<UnsettledBet> _unsettledBets;

        public CustomerProfile(IEnumerable<SettledBet> settledBets, IEnumerable<UnsettledBet> unsettledBets)
        {
            _settledBets = settledBets;
            _unsettledBets = unsettledBets;
        }

        public bool IsWiningAtUnusualRate
        {
            get {
                if (!_settledBets.Any()) return false;
                return _settledBets.Count(bet => bet.Win > 0) * 100M / _settledBets.Count() > 60;
            }
        }

        internal bool IsUpComingWiningAtUnusualRate 
        {
            get
            { 
                if (!_unsettledBets.Any()) return false;
                return _unsettledBets.Count(bet => bet.ToWin > 0) * 100M / _unsettledBets.Count() > 60;
            }
        }

        public double AverageBet
        {
            get
            { 
                if (!_settledBets.Any()) return 0;
                return _settledBets.Average(bet => bet.Stake);
            }
        }
    }
}