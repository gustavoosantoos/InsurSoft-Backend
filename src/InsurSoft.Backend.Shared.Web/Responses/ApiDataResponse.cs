using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Shared.Web.Responses
{
    public class ApiDataResponse : ApiBaseResponse
    {
        [JsonProperty(Order = 1)]
        public object Data { get; set; }

        public ApiDataResponse(bool success, object data) : base(success)
        {
            Data = data;
        }

        public ApiDataResponse(object data) : this(true, data) { }
    }
}
