using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Safeon.Systems.Core.Swagger.Model
{
    public class SwaggerHelper
    {
        private static Info descricaoApi;
        public static Action<SwaggerGenOptions> ConfigureSwaggerGenOptions;

        public static void SetDescricaoBaseApi(Info descricao)
        {
            descricaoApi = descricao;
        }

        public static void ConfigureSwaggerGen(SwaggerGenOptions swaggerGenOptions)
        {
            var webApiAssembly = Assembly.GetEntryAssembly();
            ConfigureSwaggerGenOptions?.Invoke(swaggerGenOptions);

            AddSwaggerDocPerVersion(swaggerGenOptions, webApiAssembly, descricaoApi);
            ApplyDocInclusions(swaggerGenOptions);
            IncludeXmlComments(swaggerGenOptions);
        }

        private static void IncludeXmlComments(SwaggerGenOptions swaggerGenOptions)
        {

        }

        private static void ApplyDocInclusions(SwaggerGenOptions swaggerGenOptions)
        {
            swaggerGenOptions.DocInclusionPredicate((docName, apiDesc) =>
            {
                apiDesc.TryGetMethodInfo(out MethodInfo methodInfo);

                var versions = methodInfo
                    .DeclaringType
                    .GetCustomAttribute<ApiVersionAttribute>()
                    .Versions;

                return versions.Any(v => $"v{v.ToString()}" == docName);
            });
        }

        private static void AddSwaggerDocPerVersion(SwaggerGenOptions swaggerGenOptions, Assembly webApiAssembly, Info descricaoApi = null)
        {
            var apiVersions = GetApiVersions(webApiAssembly);

            foreach (var apiVersion in apiVersions)
            {
                if (descricaoApi == null)
                {
                    descricaoApi = new Info
                    {
                        Title = "Safeon API",
                        Version = $"v{apiVersion}",
                        Description = @"API Rest",
                        Contact = new Contact()
                        {
                            Name = "Safeon",
                            Url = "http://safeon.com.br"
                        }
                    };
                }

                swaggerGenOptions.SwaggerDoc($"v{apiVersion}", descricaoApi);
            }
        }

        private static IEnumerable<string> GetApiVersions(Assembly webApiAssembly)
        {
            var apiVersion = webApiAssembly.DefinedTypes
                .Where(x => x.IsSubclassOf(typeof(Controller)) && x.GetCustomAttributes<ApiVersionAttribute>().Any())
                .Select(y => y.GetCustomAttribute<ApiVersionAttribute>())
                .SelectMany(v => v.Versions)
                .Distinct()
                .OrderBy(x => x);

            return apiVersion.Select(x => x.ToString());
        }

        public static void ConfigureSwagger(SwaggerOptions swaggerOptions)
        {
            swaggerOptions.RouteTemplate = "api-docs/{documentName}/swagger.json";
        }

        public static void ConfigureSwaggerUI(SwaggerUIOptions swaggerUIOptions)
        {
            var webApiAssembly = Assembly.GetEntryAssembly();
            var apiVersions = GetApiVersions(webApiAssembly);
            foreach (var apiVersion in apiVersions)
            {
                swaggerUIOptions.SwaggerEndpoint($"/api-docs/v{apiVersion}/swagger.json", $"V{apiVersion} Docs");
            }
            swaggerUIOptions.RoutePrefix = "api-docs";
        }

        #region properties
        public static string AwsHost { get; set; }
        public static string AwsBasePath { get; set; }
        #endregion
    }
}