using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Safeon.Systems.Core.Swagger.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Safeon.Systems.Core.Swagger.Filters
{
    public class SwaggerParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation == null || operation.Parameters == null)
                return;

            var apiDescription = context.ApiDescription;

            var controllerActionDescriptor = apiDescription.GetProperty<ControllerActionDescriptor>();
            if (controllerActionDescriptor == null)
            {
                controllerActionDescriptor = apiDescription.ActionDescriptor as ControllerActionDescriptor;

                if (controllerActionDescriptor != null)
                {
                    apiDescription.SetProperty(controllerActionDescriptor);
                }
            }

            if (controllerActionDescriptor != null)
            {
                foreach (var parm in controllerActionDescriptor.MethodInfo.GetParameters())
                {
                    var swaggerParameter = parm.GetCustomAttributes(typeof(SwaggerParameterAttribute), true).FirstOrDefault();

                    if (swaggerParameter != null)
                    {
                        var operationParameter = operation.Parameters.FirstOrDefault(p => p.Name == parm.Name);
                        if (operationParameter != null)
                        {
                            var parameter = ((SwaggerParameterAttribute)swaggerParameter);

                            operationParameter.Description = parameter.Description;
                            operationParameter.Required = parameter.Required;
                        }
                    }
                }
            }
        }
    }
}