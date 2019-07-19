using Newtonsoft.Json;
using NPVApp.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace NPVApp.Web
{
    public class BadRequestWithErrorsResult : IHttpActionResult
    {
        private ErrorDetailCollection Errors;

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            var json = JsonConvert.SerializeObject(new { Errors = Errors });
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        public BadRequestWithErrorsResult(Exception ex)
        {
            Errors = new ErrorDetailCollection();
            if (ex is ExceptionBase)
                Errors.Add(new ErrorDetail((ExceptionBase)ex));
            else
                Errors.Add(new ErrorDetail(HttpStatusCode.BadRequest, "", Util.AnErrorHasOccured));
        }
    }
}