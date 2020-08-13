using Microsoft.AspNetCore.Authorization;
using Safeon.Systems.Core.Swagger.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Safeon.Systems.Core.Swagger.Filters
{
    public class AuthorizeOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo);

            // Policy names map to scopes
            var controllerScopes = methodInfo
                .GetCustomAttributes()
                .OfType<AuthorizeHeaderRequired>()
                .Select(attr => attr);

            var actionScopes = methodInfo
                .GetCustomAttributes()
                .OfType<AuthorizeHeaderRequired>()
                .Select(attr => attr);

            var allowAnonymous = methodInfo
                .GetCustomAttributes()
                .OfType<AllowAnonymousAttribute>()
                .Select(attr => attr).Any();

            var requiredScopes = controllerScopes.Union(actionScopes).Distinct();

            operation.Responses.Add("403", new Response { Description = "Forbidden" });
            operation.Responses.Add("500", new Response { Description = "Internal Server Error" });
            operation.Responses.Add("401", new Response { Description = "Unauthorized" });

            //@todo testar novamente


            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            if (allowAnonymous == false)
            {
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "Access token",
                    Required = true,
                    Type = "string"
                });            
            }

            if (requiredScopes.Any())
            {               
                if (requiredScopes.Any(a => a.UseApiGateway))
                {
                    operation.Parameters.Add(new NonBodyParameter
                    {
                        Name = "x-api-key",
                        In = "header",
                        Description = "API Gateway access token",
                        Required = true,
                        Type = "string"
                    });
                }
            }
        }
    }
}
