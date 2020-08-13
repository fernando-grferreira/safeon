using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Safeon.Systems.Core.Swagger.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Safeon.Systems.Core.Swagger.Filters
{
    public class ComplexRequestObjectOperationFilter : IOperationFilter
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
				foreach (var parm in controllerActionDescriptor.MethodInfo.GetParameters().Where(pr => pr.ParameterType.BaseType == typeof(object)))
				{
					foreach (var p in parm.ParameterType.GetProperties())
					{
                        //@todo falta fazer uma implementação para quando o parâmetro da request tem a tag [FromBody], ver exemplos no github do projeto Swashbuckle.AspNetCore.Examples

                        var descriptionPr = p.GetCustomAttributes(typeof(DescriptionLocalized), true).FirstOrDefault();
						var operationParameter = operation.Parameters.FirstOrDefault(pr => pr.Name == p.Name);
						if (operationParameter != null && descriptionPr != null)
						{
							var parameter = ((DescriptionLocalized)descriptionPr);

							operationParameter.Description = parameter.Description;
							//operationParameter.Required = descriptionPr.Required;
						}
					}
				}
			}
		}
	}
}
