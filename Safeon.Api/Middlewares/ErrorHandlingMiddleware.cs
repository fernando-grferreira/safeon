using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Safeon.Systems.Core.Validations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Safeon.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        private static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            //catch (InvalidRequestException e)
            //{
            //    await HandleExceptionAsync(context, e);
            //}
            //catch (InvalidBusinessException e)
            //{
            //    await HandleExceptionAsync(context, e);
            //}
            //catch (InvalidRepositoryException e)
            //{
            //    _telemetryClient.TrackException(e);
            //    await HandleExceptionAsync(context, e);
            //}
            catch (Exception e)
            {
                //_telemetryClient.TrackException(e);
                await HandleExceptionAsync(context, e);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var resultError = new ErrorResult();
            resultError.AddError(exception.Message);

            var code = HttpStatusCode.Forbidden;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(resultError, JSON_SETTINGS));
        }

        //private static Task HandleExceptionAsync(HttpContext context, InvalidRequestException exception)
        //{
        //    var resultError = new ErrorResult();
        //    foreach (var error in exception.ErrorList)
        //        resultError.AddError(error);

        //    var code = HttpStatusCode.Forbidden;

        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int)code;
        //    return context.Response.WriteAsync(JsonConvert.SerializeObject(resultError, JSON_SETTINGS));
        //}

        //private static Task HandleExceptionAsync(HttpContext context, InvalidBusinessException exception)
        //{
        //    var resultError = new ErrorResult();
        //    foreach (var error in exception.ErrorList)
        //        resultError.AddError(error);

        //    var code = HttpStatusCode.Forbidden;

        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int)code;
        //    return context.Response.WriteAsync(JsonConvert.SerializeObject(resultError, JSON_SETTINGS));
        //}

        //private static Task HandleExceptionAsync(HttpContext context, InvalidRepositoryException exception)
        //{
        //    var resultError = new ErrorResult();
        //    foreach (var error in exception.ErrorList)
        //        resultError.AddError(error);

        //    var code = HttpStatusCode.Forbidden;

        //    context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int)code;
        //    return context.Response.WriteAsync(JsonConvert.SerializeObject(resultError, JSON_SETTINGS));
        //}
    }
}