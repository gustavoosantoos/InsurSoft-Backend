using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Shared.Web.Responses
{
    public static class ApiResponse
    {
        public static ApiBaseResponse Create(bool success) => new ApiBaseResponse(success);
        public static ApiBaseResponse Error(IEnumerable<string> errors) => new ApiErrorResponse(errors);
        public static ApiBaseResponse Success<T>(T data) => new ApiDataResponse<T>(data);
    }
}
