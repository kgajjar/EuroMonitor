using Euromonitor.Api.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Euromonitor.Api.Middleware
{
    /// <summary>
    /// Bringing in ILogger so we can still log out our exceptions to terminal. Useful
    /// IHostEnvironment - to check if we are in Prod or dev
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionMiddleware> _logger;

        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //Get our context and pass it on to next piece of middleware
                await _next(context);
            }
            catch (Exception ex)
            {
                //Log exception to log terminal
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                //Create a response
                //Check out enviroment
                var response = _env.IsDevelopment()
                    //In dev mode
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    //In prod mode
                    : new ApiException(context.Response.StatusCode, "internal Server Error");

                //Send back response in Json and set to Camel Case
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                //Serialise json and pass options through
                var json = JsonSerializer.Serialize(response, options);

                //return error in JSON message format
                await context.Response.WriteAsync(json);
            }
        }
    }
}
