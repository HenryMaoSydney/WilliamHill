using System.Threading.Tasks;

namespace WilliamHill.RiskProfiler
{
    public interface ICustomerProfiler
    {
          Task<CustomerProfile> GetProfile(int customerId);
    }
}