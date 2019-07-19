using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public class ErrorDetail
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Key { get; set; }
        public string Message { get; set; }

        public ErrorDetail(HttpStatusCode httpStatusCode, string key, string message)
        {
            HttpStatusCode = httpStatusCode;
            Key = key.Replace("model.", "");
            Message = message;
        }

        public ErrorDetail(ExceptionBase ex)
        {
            HttpStatusCode = ex.HttpStatusCode;
            Key = ex.Key;
            Message = ex.Message;
        }
    }
}
