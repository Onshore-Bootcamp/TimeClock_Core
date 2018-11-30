namespace TimeClock_Core.Extensions
{
    using Microsoft.AspNetCore.Http;
    using System;

    public static class HttpRequestExtensions
    {
        private const string RequestedWithHeader = "X-Requested-With";
        private const string XmlHttpRequest = "XMLHttpRequest";

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            bool isAjax = false;
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (request.Headers != null)
            {
                isAjax = request.Headers[RequestedWithHeader] == XmlHttpRequest;
            }
            return isAjax;
        }
    }
}
