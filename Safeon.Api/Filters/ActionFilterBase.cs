using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Safeon.Api.Filters
{
    public class ActionFilterBase : ActionFilterAttribute
    {
        protected string GetRequestHeaderValue(HttpRequestMessage request, string headerName)
        {
            request.Headers.TryGetValues(headerName, out IEnumerable<string> headerValues);

            return (headerValues != null && headerValues.Any()) ? headerValues.First() : string.Empty;
        }

        protected string GetRequestHeaderValue(ActionExecutingContext context, HttpRequestHeader header)
        {
            if (context.HttpContext.Request.Headers.ContainsKey(header.ToString()))
                return context.HttpContext.Request.Headers[header.ToString()].ToString();

            return null;
        }
    }
}