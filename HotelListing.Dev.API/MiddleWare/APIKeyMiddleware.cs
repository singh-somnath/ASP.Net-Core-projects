namespace HotelListing.Dev.API.MiddleWare
{
    public class APIKeyMiddleware : IMiddleware
    {
        private const string AuthoriationHeaderTitle = "AUTH";

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
          
            try
            {
                var path = Convert.ToString(context.Request.Path);

                if (path.Contains("/api/"))
                {
                    if (!context.Request.Headers.TryGetValue(AuthoriationHeaderTitle, out var authValue))
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Unauthorized Request");
                        return;
                    }
                    if (authValue.ToString().ToUpper() != "AXXPA0117ACLTPS4286A")
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        await context.Response.WriteAsync("Invalid API Key");
                        return;
                    }
                }
                else
                {
                    Console.Write("Outside Secure API\n");
                }
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync($"{ex.Message}");
                return;
            }
           
           
        }
    }
}
