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
using System.Web.Http.ModelBinding;

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

        public BadRequestWithErrorsResult(ModelStateDictionary modelStateDictionary, string errorMessage = null)
        {
            Errors = new ErrorDetailCollection();
            foreach (var key in modelStateDictionary.Keys)
            {
                var modelStateItem = modelStateDictionary[key];
                var stringErrors = string.Join("<br/>",
                    modelStateItem.Errors.Where(m => m.ErrorMessage.IsNotEmpty()).Select(m => m.ErrorMessage).Distinct());
                var error = new ErrorDetail(HttpStatusCode.BadRequest, key, stringErrors);
                Errors.Add(error);
            }

            if (!Errors.Any(m => m.Key == string.Empty))
            {
                Errors.Insert(0, new ErrorDetail(HttpStatusCode.BadRequest, "", errorMessage ?? Util.ValidationIssues));
            }
        }
    }
}