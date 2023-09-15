public class TimeMiddleware
{
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(HttpContext context)
    {
        await next(context);
        
        if (context.Request.Query.Any(parameter => parameter.Key == "time"))
        {
            await context.Response.WriteAsJsonAsync(DateTime.Now.ToShortTimeString());
        }
        
    }

}
public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder useTimeMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}