using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IndiaWalks.Middleware
{
    public class ExceptionHandler
    {
        private readonly ILogger<ExceptionHandler> logger1;
        private readonly RequestDelegate next;

        public ExceptionHandler(ILogger<ExceptionHandler> logger1, RequestDelegate next)
        {
            this.logger1 = logger1;
            this.next = next;

        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {

                var errorId = Guid.NewGuid();
                logger1.LogError(ex, $"{errorId}:{ex.Message}");

                //return custom response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong! we are looking in to this"
                };
                await httpContext.Response.WriteAsJsonAsync(error);

            }
        }
    }
}
