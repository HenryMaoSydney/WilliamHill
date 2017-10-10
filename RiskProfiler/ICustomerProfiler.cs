namespace WilliamHill.RiskProfiler
{
    public interface ICustomerProfiler
    {
        CustomerProfile GetProfile(int customerId);
    }
}