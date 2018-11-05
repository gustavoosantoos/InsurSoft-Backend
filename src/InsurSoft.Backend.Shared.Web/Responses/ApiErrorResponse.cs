using System.Collections.Generic;
using Newtonsoft.Json;

namespace InsurSoft.Backend.Shared.Web.Responses
{
    public class ApiErrorResponse : ApiBaseResponse
    {
        [JsonProperty(Order = 1)]
        public IEnumerable<string> Errors { get; set; }

        public ApiErrorResponse(bool success, IEnumerable<string> errors) : base(success)
        {
            Errors = errors;
        }

        public ApiErrorResponse(IEnumerable<string> errors) : this(false, errors)
        {

        }
    }
}
