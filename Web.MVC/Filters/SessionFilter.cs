using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.MVC.Filters
{
    public class SessionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next
            )
        {
            var services = context.HttpContext.RequestServices;
            var session = services.GetService(typeof(SessionContext)) as SessionContext;

            var userContext = context.HttpContext.User;

            var userIdClaim = userContext.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                session.UserId = new Guid(userIdClaim.Value);
            }

            var userNameClaim = userContext.FindFirst(ClaimTypes.Name);
            if (userNameClaim != null)
            {
                session.Username = userNameClaim.Value;
            }

            var resultContext = await next();
        }
    }
}
