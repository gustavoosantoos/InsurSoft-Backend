using Newtonsoft.Json;

namespace InsurSoft.Backend.Shared.Web.Responses
{
    public class ApiBaseResponse
    {
        [JsonProperty(Order = 0)]
        public bool Success { get; set; }

        public ApiBaseResponse(bool success) => Success = success;
    }
}
