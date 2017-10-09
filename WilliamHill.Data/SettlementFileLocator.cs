using System;

namespace WilliamHill.Data
{
    public class SettlementFileLocator : ISettlementFileLocator
    {
        public String LocateSettleCsv
        {
            get { return @"Settled.csv"; }
        }

        public String LocateUnSettleCsv {
            get { return @"UnSettled.csv"; }
        }
    }
}