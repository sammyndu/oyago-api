using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Oyago.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Oyago.Application.Exceptions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;


        }

        public async Task InvokeAsync(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);


            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An error occurred");
            //var getLanguage = Convert.ToString(context.Request.Headers[ResponseCodes.LANGUAGE]);
            context.Response.ContentType = "Application/json";
            context.Response.StatusCode = 500;

            var response = context.Response;

            var message = string.Empty;

            var errorResponse = new ErrorResponse
            {
                ResponseDescription = "an error occurred",
                ResponseCode = "999"

            };
            //CaseSwirching(exception, messageProvider, getLanguage, response, errorResponse);
            var result = JsonConvert.SerializeObject(errorResponse);
            await context.Response.WriteAsync(result);
        }

        //private void CaseSwirching(Exception exception, IMessageProvider messageProvider, string getLanguage, HttpResponse response, ErrorResponse errorResponse)
        //{
        //    switch (exception)
        //    {
        //        case ApplicationException ex:
        //            if (ex.Message.Contains("Invalid token"))
        //            {
        //                response.StatusCode = (int)HttpStatusCode.Forbidden;
        //                errorResponse.responseDescription = messageProvider.GetMessage(ResponseCodes.INVALID_TOKEN, getLanguage);
        //                errorResponse.responseCode = ResponseCodes.INVALID_TOKEN;
        //                _logger.LogError(ex, "Invalid token");
        //                break;
        //            }
        //            response.StatusCode = (int)HttpStatusCode.BadRequest;
        //            errorResponse.responseDescription = messageProvider.GetMessage(ResponseCodes.BAD_REQUEST, getLanguage);
        //            errorResponse.responseCode = ResponseCodes.BAD_REQUEST;
        //            _logger.LogError(ex, "Bad request");
        //            break;
        //        case KeyNotFoundException ex:
        //            response.StatusCode = (int)HttpStatusCode.NotFound;
        //            errorResponse.responseDescription = messageProvider.GetMessage(ResponseCodes.NOT_FOUND, getLanguage);
        //            errorResponse.responseCode = ResponseCodes.NOT_FOUND;
        //            _logger.LogError(ex, "Not found");
        //            break;
        //        default:
        //            response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //            errorResponse.responseDescription = messageProvider.GetMessage(ResponseCodes.EXCEPTION, getLanguage);
        //            errorResponse.responseCode = ResponseCodes.EXCEPTION;
        //            _logger.LogError("An error occurred");
        //            break;
        //    }
        //    _logger.LogError(exception.Message);
        //}
    }
}
