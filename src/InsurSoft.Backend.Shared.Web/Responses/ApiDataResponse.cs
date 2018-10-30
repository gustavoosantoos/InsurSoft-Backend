using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Shared.Web.Responses
{
    public class ApiDataResponse<T> : ApiBaseResponse
    {
        [JsonProperty(Order = 1)]
        public object Data { get; set; }

        public ApiDataResponse(bool success, T data) : base(success)
        {
            Data = data;
        }

        public ApiDataResponse(T data) : this(true, data) { }
    }
}
