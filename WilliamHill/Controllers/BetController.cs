using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
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
        public async Task<List<BetRiskModel>> DisplayAllUnsettledBetWithRisk()
        {
            var unsettledbets = await _riskRepository.GetAllUnSettledBets();
            List <BetRiskModel> betRisks= new List<BetRiskModel>();
            foreach (var bet in unsettledbets)
            {
                CustomerProfile customerProfile = await _customerProfiler.GetProfile(bet.CustomerId);
                BetProfile betProfile  = await _betProfiler.GetProfile(bet, customerProfile);
                betRisks.Add( new BetRiskModel( bet, betProfile.Status));
            }

            return betRisks;
        }

    }
}
