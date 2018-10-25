using System;
using System.Collections.Generic;
using System.Text;

namespace InsurSoft.Backend.Shared.Web.Responses
{
    public static class ApiResponse
    {
        public static ApiBaseResponse Create(bool success) => new ApiBaseResponse(success);
        public static ApiBaseResponse Error(object errors) => new ApiErrorResponse(errors);
        public static ApiBaseResponse Success(object data) => new ApiDataResponse(data);
    }
}
