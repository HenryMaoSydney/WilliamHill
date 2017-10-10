using System;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Web;

namespace WilliamHill.Data
{
    public class SettlementFileLocator : ISettlementFileLocator
    {
        public String LocateSettleCsv
        {
            get { return HttpContext.Current.Server.MapPath("~/Settled.csv"); }
        }

        public String LocateUnSettleCsv {
            get
            {
                return HttpContext.Current.Server.MapPath("~/UnSettled.csv"); 
            }
        }
    }
}