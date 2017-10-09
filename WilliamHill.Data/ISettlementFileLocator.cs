namespace WilliamHill.Data
{
    public interface ISettlementFileLocator
    {
        string LocateUnSettleCsv { get; }
        string LocateSettleCsv { get; }
    }
}