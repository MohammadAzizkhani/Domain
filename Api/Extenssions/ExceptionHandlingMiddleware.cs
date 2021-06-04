using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Api.Extenssions
{

    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger
        )
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            string result = string.Empty;
            if (ex is MMSPortalException businessException)
            {
                result = System.Text.Json.JsonSerializer.Serialize(new { businessException.Message, businessException.Code });
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                _logger.LogError(ex, $"Unhandled exception has occurred. {ex.Message}");
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result = System.Text.Json.JsonSerializer.Serialize(new { Message = "Internal Server Error!", Code = -1 });
            }

            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(result);
        }
    }
}
