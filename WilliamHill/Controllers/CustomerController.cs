using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WilliamHill.Data.Models;
using WilliamHill.RiskProfiler;

namespace WilliamHill.Controllers
{ 

    public class CustomerController : ApiController
    {
        private readonly ICustomerProfiler _customerProfiler;

        public CustomerController(ICustomerProfiler customerProfiler)
        {
            _customerProfiler = customerProfiler;
        }

        /// <summary>
        ///     Get RiskProfile for Customer
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [Route("CustomerRiskProfiler/{CustomerId}")]
        public async Task<CustomerProfile> GetRiskProfiler(int CustomerId)
        {
            var customerProfile = await _customerProfiler.GetProfile(CustomerId); 

            return customerProfile;
        }
    }
}