using System;
using System.Net;
using System.Text.Json;
using CManagerApplication.Exceptions;

namespace CManagerAPI.Helpers.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case KeyNotFoundException:
                    case EntityNotFoundException: 
                        response.StatusCode = (int) HttpStatusCode.NotFound;
                        break;
                    case AccessDeniedException:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    default:
                        response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new
                {
                    message = error?.Message,
                    statusCode = context.Response.StatusCode
                });

                await response.WriteAsync(result);
            }
        }
    }
}

