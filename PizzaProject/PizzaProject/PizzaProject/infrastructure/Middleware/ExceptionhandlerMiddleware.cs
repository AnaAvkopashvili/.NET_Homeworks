using Newtonsoft.Json;

namespace PizzaRestaurant.API.infrastructure.Middleware
{
    public class ExceptionHandlerMiddlware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);

            }
            catch (Exception ex)
            {
                LogException(ex, context.Request);
                await HandleExceptionAsync(context, ex);
            }
        }
        private void LogException(Exception ex, HttpRequest request)
        {
            string path = @"C:\\Users\\Kiu-Student\\Desktop\\log.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"Timestamp: {DateTime.UtcNow}");
                sw.WriteLine($"Request Method: {request.Method}");
                sw.WriteLine($"Request Path: {request.Path}");
                sw.WriteLine("Message: " + ex.Message);
                sw.WriteLine("Stack trace: " + ex.StackTrace);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var error = new GlobalExceptionHandler(context, ex);
            var result = JsonConvert.SerializeObject(error);

           // context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = error.Status.Value;

            await context.Response.WriteAsync(result);
        }
    }
}
