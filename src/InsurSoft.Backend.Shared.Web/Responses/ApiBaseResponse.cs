using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace InsurSoft.Backend.Shared.Web.Responses
{
    public class ApiBaseResponse
    {
        [JsonProperty(Order = 0)]
        public bool Success { get; set; }

        public ApiBaseResponse(bool success) => Success = success;
    }
}
