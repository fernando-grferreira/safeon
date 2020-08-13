using Safeon.Systems.Core.Swagger.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Safeon.Systems.Core.Swagger.Filters
{
    public class NonBodyParameterFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo);

            // Policy names map to scopes
            var controllerScopes = methodInfo
                .GetCustomAttributes()
                .OfType<NonBodyParameterAttribute>()
                .Select(attr => attr);

            var actionScopes = methodInfo
                .GetCustomAttributes()
                .OfType<NonBodyParameterAttribute>()
                .Select(attr => attr);

            var requiredScopes = controllerScopes.Union(actionScopes).Distinct();

            if (requiredScopes.Any())
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<IParameter>();

                foreach (var item in requiredScopes)
                {
                    operation.Parameters.Add(item.Parameter);
                }
            }
        }
    }
}
