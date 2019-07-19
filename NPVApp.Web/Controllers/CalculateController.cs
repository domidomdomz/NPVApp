using NPVApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NPVApp.Web.Controllers
{
    public class CalculateController : ApiController
    {
        protected ICalculationLogic CalculationLogic;

        public CalculateController(ICalculationLogic calculationLogic)
        {
            CalculationLogic = calculationLogic;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("api/npv/calculate")]
        public async Task<IHttpActionResult> CreateConsignment(CalculateNPVApiRequest request)
        {
            try
            {
                var requestId = await CalculationLogic.ManageNPVCalculation(request);
                return Ok(requestId);
            }
            catch (Exception ex)
            {
                // Put logging here
                return new BadRequestWithErrorsResult(ex);
            }

        }
    }
}
