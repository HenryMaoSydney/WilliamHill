using System.Threading.Tasks;
using WilliamHill.Data.Models;

namespace WilliamHill.RiskProfiler
{
    public interface IBetProfiler
    {
        Task<BetProfile> GetProfile(UnsettledBet bet, CustomerProfile customerProfile);
    }
}