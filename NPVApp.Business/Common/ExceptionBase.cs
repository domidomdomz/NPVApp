using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NPVApp.Business
{
    public abstract class ExceptionBase : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Key { get; set; }
        public ExceptionBase(HttpStatusCode httpStatusCode, string key, string message) :
            base(message)
        {
            Key = key;
            HttpStatusCode = httpStatusCode;
        }
    }
}
