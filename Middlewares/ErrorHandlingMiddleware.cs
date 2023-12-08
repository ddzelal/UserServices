using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UserRepository.Errors;

namespace UserRepository.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private const string errorMessage = "Error has occurred while processing your request, please try again.";
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IHostEnvironment hostEnvironment)
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            switch (ex)
            {
                case BadRequestException badRequestEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    IEnumerable<string> errorMessages = badRequestEx?.Messages ?? new List<string>();
                    return context.Response.WriteAsync(JsonSerializer.Serialize(new { errors = errorMessages }));

                case NoUserFoundException noUserFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    errorMessages = noUserFoundException?.Messages ?? new List<string>();
                    return context.Response.WriteAsync(JsonSerializer.Serialize(new { errors = errorMessages }));

                default:
                    _logger.LogError(ex, ex.ToString());
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    //if (_hostEnvironment.IsDevelopment())
                    //{
                    //}
                    return context.Response.WriteAsync(JsonSerializer.Serialize(
                        new { error = $"{ex.Message} + {ex.StackTrace} + {ex.Source}" }));
                    //return context.Response.WriteAsync(JsonSerializer.Serialize(new { error = errorMessage }));
            }
        }
    }

}