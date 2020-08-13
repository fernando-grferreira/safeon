using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Net;

namespace Safeon.Api.Filters
{
    public class AuthorizationValidationFilter : ActionFilterBase
    {
        public AuthorizationValidationFilter() { }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var anonymousAccessAllowed = false;

            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                var actionAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true);
                if (actionAttributes.OfType<AllowAnonymousAttribute>().Any())
                {
                    anonymousAccessAllowed = true;
                }
            }

            if (anonymousAccessAllowed == false)
            {
                var authKey = GetRequestHeaderValue(context, HttpRequestHeader.Authorization);

                //var userSession = Container.GetContainer().GetInstance<IUserSession>();
                //var userBusiness = Container.GetContainer().GetInstance<IUserBusiness>();

                //if (string.IsNullOrEmpty(authKey) || !(userBusiness.AuthenticateToken(authKey).Result is User user))
                //{
                //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

                //    var retorno = new ErrorResult(true);
                //    string error = string.IsNullOrEmpty(authKey) ? Language.Systems.AccessTokenIsMissing : Language.Systems.AccessTokenNotAuthorization;
                //    retorno.AddError(error);
                //    context.Result = new JsonResult(retorno);

                //    return;
                //}

                //userSession.UserId = user.Id;
                //userSession.ClientId = user.ClientId;
                //userSession.Master = user.Master;
                //userSession.AllVehicles = user.AllVehicles;                           
                //userSession.Username = user.Username;                           
            }

            base.OnActionExecuting(context);
        }
    }
}