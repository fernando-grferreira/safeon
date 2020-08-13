using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace Safeon.Systems.Core.Swagger.Filters.ApiGateway
{
    public class AwsApiGatewaySecurity : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Extensions.Add("security", new List<object>()
            {
                new { api_key = new List<string>() }
            });
        }
    }
}
