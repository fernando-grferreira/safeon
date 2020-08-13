using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace Safeon.Api.Filters
{
    /// <seealso cref="https://www.devtrends.co.uk/blog/dependency-injection-in-action-filters-in-asp.net-core"/>
    public class TelemetryActionFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            return next.Invoke();
        }
    }
}