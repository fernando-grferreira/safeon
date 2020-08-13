using Safeon.Systems.Core.Swagger.Model;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Safeon.Systems.Core.Swagger.Filters.ApiGateway
{
    public class AwsDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            if (string.IsNullOrEmpty(SwaggerHelper.AwsBasePath)
                || string.IsNullOrEmpty(SwaggerHelper.AwsHost))
                throw new AwsConfigurationException("Set properties SwaggerHelper.AwsBasePath and SwaggerHelper.AwsHost");

            swaggerDoc.Host = SwaggerHelper.AwsHost;
            swaggerDoc.Schemes = new List<string>()
            {
                "https"
            };
            swaggerDoc.BasePath = SwaggerHelper.AwsBasePath;
            
            for (var i = 0; i < swaggerDoc.Definitions.Count(); i++)
            {
                var definition = swaggerDoc.Definitions.ElementAt(i);
                var split = definition.Key.Split('/');
                split[split.Length - 1] = Regex.Replace(split[split.Length - 1], "[^0-9a-zA-Z]+", "");
                var definitionValue = definition.Value;
                swaggerDoc.Definitions.Remove(definition.Key);
                swaggerDoc.Definitions.Add(string.Join("/", split), definitionValue);
            }

            swaggerDoc.Definitions.Add("Empty",
                new Schema() { Type = "object", Title = "Empty Schema" });
        }
    }

    public class AwsConfigurationException : Exception
    {
        public AwsConfigurationException(string message) : base(message)
        {
        }
    }
}
