using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WilliamHill.RiskProfiler;

namespace WilliamHill.Controllers
{
    public class BetController : ApiController
    {

        private readonly IBetProfiler _betProfiler;

        public BetController(IBetProfiler betProfiler)
        {
            _betProfiler = betProfiler;
        }

    }
}
