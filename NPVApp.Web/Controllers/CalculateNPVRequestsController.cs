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
    public class CalculateNPVRequestsController : ApiController
    {
        protected ICalculateNPVRequestsLogic CalculateNPVRequestsLogic;
        public CalculateNPVRequestsController(ICalculateNPVRequestsLogic calculateNPVRequestsLogic)
        {
            CalculateNPVRequestsLogic = calculateNPVRequestsLogic;
        }

        [HttpGet]
        [Route("api/npv/requests")]
        public async Task<IHttpActionResult> Get()
        {

            try
            {
                var calculateNPVRequests = await CalculateNPVRequestsLogic.GetAllAsync("", null, "CalculateNPVRequests.CreateDate");
                return Ok(calculateNPVRequests);
            }
            catch (Exception ex)
            {
                // Put logging here
                return new BadRequestWithErrorsResult(ex);
            }
        }

        [HttpGet]
        [Route("api/npv/requests")]
        public async Task<IHttpActionResult> GetById(int id)
        {

            try
            {
                var calculateNPVRequest = await CalculateNPVRequestsLogic.GetAsync(id);
                return Ok(calculateNPVRequest);
            }
            catch (Exception ex)
            {
                // Put logging here
                return new BadRequestWithErrorsResult(ex);
            }
        }


    }
}
