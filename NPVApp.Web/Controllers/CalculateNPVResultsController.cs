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
    public class CalculateNPVResultsController : ApiController
    {
        protected ICalculateNPVResultsLogic CalculateNPVResultsLogic;
        public CalculateNPVResultsController(ICalculateNPVResultsLogic calculateNPVResultsLogic)
        {
            CalculateNPVResultsLogic = calculateNPVResultsLogic;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/npv/results")]
        public async Task<IHttpActionResult> GetByRequestId(int id)
        {
            try
            {
                var result = await CalculateNPVResultsLogic.GetByRequestId(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Put logging here
                return new BadRequestWithErrorsResult(ex);
            }
        }
    }
}
