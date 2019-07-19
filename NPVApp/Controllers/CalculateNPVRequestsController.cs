using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NPVApp.Web.Controllers
{
    public class CalculateNPVRequestsController : ApiController
    {
        [HttpGet]
        [Route("api/npv/requests")]
        public async Task<IHttpActionResult> Get()
        {

            var mockCalculateRequests = new List<CalculateNPVRequest>
            {
                new CalculateNPVRequest
                {
                    InitialInvestment = 10000,
                    LowerBoundDiscountRate = 0.01,
                    UpperBoundDiscountRate = 0.015,
                    DiscountRateIncrement = 0.0025,
                    CashFlowValues = "1000, 2000, 1000"
                }
            };

            return Json(mockCalculateRequests);
        }


    }

    public class CalculateNPVRequest
    {
        public decimal InitialInvestment { get; set; }
        public double LowerBoundDiscountRate { get; set; }
        public double UpperBoundDiscountRate { get; set; }
        public double DiscountRateIncrement { get; set; }
        public string CashFlowValues { get; set; }
    }
}
