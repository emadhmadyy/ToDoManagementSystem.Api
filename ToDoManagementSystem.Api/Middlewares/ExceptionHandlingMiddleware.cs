using System.Net;
using System.Text.Json;

namespace ToDoManagementSystem.Api.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (HttpStatusException ex)
            {
                // Custom application exception with status code
                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    message = ex.Message
                };

                await context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {
                // Unexpected server errors
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                #if DEBUG
                var response = new { message = ex.Message };
                #else
                var response = new { message = "An internal server error occurred." };
                #endif

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
