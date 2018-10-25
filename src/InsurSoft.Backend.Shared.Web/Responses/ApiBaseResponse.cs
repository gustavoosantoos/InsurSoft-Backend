using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Shared.Web.Responses
{
    public class ApiBaseResponse
    {
        [JsonProperty(Order = 0)]
        public bool Success { get; set; }

        public ApiBaseResponse(bool success) => Success = success;
    }
}
