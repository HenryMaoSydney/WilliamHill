namespace WilliamHill.RiskProfiler
{
    public interface ICustomerProfiler
    {
        CustomerProfile GetProfiler(int customerId);
    }
}