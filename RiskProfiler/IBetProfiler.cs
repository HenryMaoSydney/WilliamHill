using WilliamHill.Data.Models;

namespace WilliamHill.RiskProfiler
{
    public interface IBetProfiler
    {
        BetProfile GetProfile(UnsettledBet bet, CustomerProfile customerProfile);
    }
}