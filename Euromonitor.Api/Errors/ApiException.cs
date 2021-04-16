using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euromonitor.Api.Errors
{
    public class ApiException
    {
        public ApiException(int statusCode, string message = null, string details = null)//Initialize to null, so that there is no need to always provide the properties.
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}
