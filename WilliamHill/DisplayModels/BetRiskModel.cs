using WilliamHill.Data.Models;

namespace WilliamHill.Controllers
{
    public class BetRiskModel
    {
        public UnsettledBet Bet { get; }
        public string RiskStatus { get; }

        public BetRiskModel(UnsettledBet bet, string riskStatus)
        {
            Bet = bet;
            RiskStatus = riskStatus;
        }
    }
}