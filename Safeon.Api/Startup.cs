using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Safeon.Api.Filters;
using Safeon.Api.Middlewares;
using Safeon.IOC;
using Safeon.Systems.Core.Swagger.Filters;
using Safeon.Systems.Core.Swagger.Model;
using Swashbuckle.AspNetCore.Filters;

namespace Safeon.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            SwaggerHelper.SetDescricaoBaseApi(new Swashbuckle.AspNetCore.Swagger.Info()
            {
                Title = "Safeon",
                Description = "API Safeon"
            });

            Container.Init();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Container.InitServices(services);

            //Adding to export for aws
            //SwaggerHelper.AwsHost = "https://k3o06x1sqk.execute-api.sa-east-1.amazonaws.com/homolog";
            //SwaggerHelper.AwsBasePath = "/safeon/v1/";

            SwaggerHelper.ConfigureSwaggerGenOptions = swaggerGenOptions =>
            {
                //swaggerGenOptions.OperationFilter<DescriptionOperationFilter>();
                swaggerGenOptions.OperationFilter<SwaggerParameterOperationFilter>();
                swaggerGenOptions.OperationFilter<ComplexRequestObjectOperationFilter>();
                //swaggerGenOptions.AddSwaggerExamples(services.BuildServiceProvider());
                swaggerGenOptions.OperationFilter<NonBodyParameterFilter>();
                swaggerGenOptions.OperationFilter<AuthorizeOperationFilter>();
                //swaggerGenOptions.DocumentFilter<HideInDocsFilter>();

                //swaggerGenOptions.OperationFilter<AddFileParamTypesOperationFilter>();
                swaggerGenOptions.OperationFilter<AddResponseHeadersFilter>();
                swaggerGenOptions.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //Adding filter classes to Swagger for AWS
                //swaggerGenOptions.OperationFilter<Tools.Swagger.AspNetCore.Filters.ApiGateway.AwsApiGatewaySecurity>();
                //swaggerGenOptions.OperationFilter<Tools.Swagger.AspNetCore.Filters.ApiGateway.AwsApiGatewayIntegrationFilter>();
                //swaggerGenOptions.DocumentFilter<Tools.Swagger.AspNetCore.Filters.ApiGateway.AwsDocumentFilter>();

                //Adding parameter x-api-key to all methods, required for import for AWS
                //swaggerGenOptions.AddSecurityDefinition("api_key",
                //    new Swashbuckle.AspNetCore.Swagger.ApiKeyScheme() { Type = "apiKey", Name = "x-api-key", In = "header" }
                //);
            };

            services.AddMvc(options =>
            {
                options.Filters.Add(new AuthorizationValidationFilter());
            });
            //.AddFluentValidation(fv =>
            //{
            //    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            //    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
            //});

            services.AddSwaggerGen(SwaggerHelper.ConfigureSwaggerGen);

            //preenche informações sobre as controllers nas telemetrias de requisições
            services.AddMvc(options => options.Filters.Add<TelemetryActionFilter>());

            //var requestTrackingTelemetryModule = services
            //    .FirstOrDefault<ServiceDescriptor>(t => t.ImplementationType ==
            //        typeof(Microsoft.ApplicationInsights.AspNetCore.RequestTrackingTelemetryModule));

            //if (requestTrackingTelemetryModule != null)
            //    services.Remove(requestTrackingTelemetryModule);

            //ApplicationInsightsExtensions.AddApplicationInsightsTelemetryProcessor<CorrelationTelemetryProcessor>(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Register application
            Container.InitApplication(app, env);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(SwaggerHelper.ConfigureSwagger);
            app.UseSwaggerUI(SwaggerHelper.ConfigureSwaggerUI);

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }
    }
}
