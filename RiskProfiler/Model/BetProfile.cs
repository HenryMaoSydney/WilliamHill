using System.Collections.Generic;
using System.Linq;

namespace WilliamHill.RiskProfiler
{
    public class BetProfile
    {
        public bool IsBetLargeSum { get; }
        public bool IsHighlyUnusual { get; }
        public bool IsUnusual { get; }
        public bool IsRisk { get; }

        public BetProfile( bool isBetLargeSum, bool isHighlyUnusual, bool isUnusual, bool isRisk)
        {
            IsBetLargeSum = isBetLargeSum;
            IsHighlyUnusual = isHighlyUnusual;
            IsUnusual = isUnusual;
            IsRisk = isRisk;
        }

        public string Status {
            get
            {
                List<string> statustoken = new List<string>();
                if (IsBetLargeSum) statustoken.Add("LargeSum");
                if (IsHighlyUnusual) statustoken.Add("Highly Unusual");
                else if (IsUnusual) statustoken.Add("Unusual");
                if (IsRisk) statustoken.Add("Risk");

                if (!statustoken.Any()) return "Normal";
                return string.Join(",", statustoken);
            }
        }
    }
}