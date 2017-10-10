using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebGrease.Css.Extensions;
using WilliamHill.Data;
using WilliamHill.RiskProfiler;

namespace WilliamHill.Controllers
{
    public class BetController : ApiController
    {

        private readonly ICustomerProfiler  _customerProfiler;
        private readonly IBetProfiler _betProfiler;

        private readonly IRiskRepository _riskRepository;

        public BetController(IBetProfiler betProfiler, IRiskRepository riskRepository, ICustomerProfiler customerProfiler)
        {
            _betProfiler = betProfiler;
            _riskRepository = riskRepository;
            _customerProfiler = customerProfiler; 
        }

        /// <summary>
        /// Get RiskProfile for Customer
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpGet]
        [System.Web.Http.Route("DisplayAllUnsettledBetWithRisk")]
        public async Task<IEnumerable<BetRiskModel>> DisplayAllUnsettledBetWithRisk()
        {
            var unsettledbets = await _riskRepository.GetAllUnSettledBets();
            ConcurrentBag<BetRiskModel> betRisks= new ConcurrentBag<BetRiskModel>();

            // Note CustomerProfile is retrieved for EVERY unsettled bet. maybe a local cache of CustomerProfile could be hold to minimise the repetition, 
            // howewver, Business Logic may requires us always retrieve latest customer profile from data source?
            // 
             Parallel.ForEach(unsettledbets, async bet =>
            {
                CustomerProfile customerProfile = await _customerProfiler.GetProfile(bet.CustomerId);
                BetProfile betProfile = await _betProfiler.GetProfile(bet, customerProfile);
                betRisks.Add(new BetRiskModel(bet, betProfile.Status));
            });

            return betRisks;
        }

    }
}
