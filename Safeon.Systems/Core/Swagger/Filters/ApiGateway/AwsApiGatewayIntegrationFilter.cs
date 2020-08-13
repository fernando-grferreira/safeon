using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Safeon.Systems.Core.Swagger.Filters.ApiGateway
{
    public class AwsApiGatewayIntegrationFilter : IOperationFilter
    {
        private const string Format = "http://${{stageVariables.url}}/{0}";

        public void Apply(Operation operation, OperationFilterContext context)
        {
            context.ApiDescription.TryGetMethodInfo(out MethodInfo methodInfo);

            var allowAnonymous = methodInfo
                .GetCustomAttributes()
                .OfType<AllowAnonymousAttribute>()
                .Select(attr => attr).Any();
            var httpMethod = context.ApiDescription.HttpMethod.ToUpper();

            var requestParameters = new Dictionary<string, string>()
            {
                {"integration.request.header.Content-Type",
                    "method.request.header.Content-Type"}
            };

            var cacheKeyParameters = new List<string>();

            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();
            else if (httpMethod == "GET" ||
                     httpMethod == "PUT" ||
                     httpMethod == "DELETE" ||
                     httpMethod == "POST")
            {
                foreach (var parameter in operation.Parameters)
                {
                    if (parameter.Name != "Authorization"
                        && parameter.Name != "x-api-key"
                        && parameter.In != "body")
                    {
                        var type = GetParameterType(parameter.In);

                        requestParameters.Add(
                            $"integration.request.{type}.{parameter.Name}",
                            $"method.request.{type}.{parameter.Name}"
                        );

                        if (httpMethod == "GET")
                        {
                            cacheKeyParameters.Add($"method.request.{type}.{parameter.Name}");
                        }
                    }
                }
            }

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "Content-Type",
                In = "header",
                Description = "Content-Type",
                Required = false,
                Type = "string"
            });

            if (allowAnonymous == false)
            {
                requestParameters.Add("integration.request.header.Authorization",
                    "method.request.header.Authorization");

                if (httpMethod == "GET")
                {
                    cacheKeyParameters.Add("method.request.header.Authorization");
                }

                if (!operation.Parameters.Any(x => x.Name == "Authorization"))
                    operation.Parameters.Add(new NonBodyParameter
                    {
                        Name = "Authorization",
                        In = "header",
                        Description = "Access token",
                        Required = true,
                        Type = "string"
                    });
            }

            operation.Extensions.Add("x-amazon-apigateway-integration", new
            {
                uri = string.Format(Format, context.ApiDescription.RelativePath),
                responses = new Dictionary<string, object>()
                {
                    {
                        "202",
                        new { statusCode = "202" }
                    },
                    {
                        "401",
                        new { statusCode = "401" }
                    },
                    {
                        "403",
                        new { statusCode = "403" }
                    },
                    {
                        "404",
                        new { statusCode = "404" }
                    },
                    {
                        "200",
                        new { statusCode = "200" }
                    },
                    {
                        "500",
                        new { statusCode = "500" }
                    }
                },
                requestParameters,
                passthroughBehavior = "when_no_match",
                httpMethod = context.ApiDescription.HttpMethod,
                cacheNamespace = "yzjdv3",
                cacheKeyParameters,
                type = "http"
            });

            operation.Consumes = new List<string>();

            foreach (var responsesValue in operation.Responses.Values)
            {
                if (responsesValue.Schema != null
                    && responsesValue.Schema.Ref != null)
                {
                    var split = responsesValue.Schema.Ref.Split('/');
                    split[split.Length - 1] = Regex.Replace(split[split.Length - 1], "[^0-9a-zA-Z]+", "");
                    responsesValue.Schema.Ref = string.Join("/", split);
                }
            }

            if (operation.Responses.Values.Any(x => x.Schema != null && x.Schema.Type != null
                                                    && (x.Schema.Type.ToLower() == "array"
                                                        || x.Schema.Type.ToLower() == "string"
                                                        || x.Schema.Type.ToLower() == "boolean"
                                                        || x.Schema.Type.ToLower() == "integer")))
            {
                operation.Responses = new Dictionary<string, Response>()
                {
                    {
                        "200",
                        new Response()
                        {
                            Description = "200 response",
                            Schema = new Schema() {Ref = "#/definitions/Empty"}
                        }
                    },
                    {
                        "202",
                        new Response()
                        {
                            Description = "202 response",
                            Schema = new Schema() {Ref = "#/definitions/Empty"}
                        }
                    },
                    {
                        "401",
                        new Response()
                        {
                            Description = "401 response",
                            Schema = new Schema() {Ref = "#/definitions/Empty"}
                        }
                    },
                    {
                        "403",
                        new Response()
                        {
                            Description = "403 response",
                            Schema = new Schema() {Ref = "#/definitions/Empty"}
                        }
                    },
                    {
                        "404",
                        new Response()
                        {
                            Description = "404 response",
                            Schema = new Schema() {Ref = "#/definitions/Empty"}
                        }
                    },
                    {
                        "500",
                        new Response()
                        {
                            Description = "500 response",
                            Schema = new Schema() {Ref = "#/definitions/Empty"}
                        }
                    }
                };
            }
        }
        private string GetParameterType(string @in)
        {
            switch (@in)
            {
                case "path":
                    return "path";
                case "query":
                    return "querystring";
                default:
                    return "header";
            }
        }
    }
}

