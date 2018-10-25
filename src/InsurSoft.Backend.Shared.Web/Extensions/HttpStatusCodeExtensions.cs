using System.Net;

namespace InsurSoft.Backend.Shared.Web.Extensions
{
    public static class HttpStatusCodeExtensions
    {
        public static int ToInt(this HttpStatusCode statusCode)
        {
            return (int) statusCode;
        }
    }
}
