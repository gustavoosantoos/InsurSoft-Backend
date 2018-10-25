using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Shared.Web.Responses
{
    public class ApiErrorResponse : ApiBaseResponse
    {
        [JsonProperty(Order = 1)]
        public object Errors { get; set; }

        public ApiErrorResponse(bool success, object errors) : base(success)
        {
            Errors = errors;
        }

        public ApiErrorResponse(object errors) : this(false, errors)
        {

        }
    }
}
