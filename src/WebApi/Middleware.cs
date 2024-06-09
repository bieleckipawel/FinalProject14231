using System.Text;

namespace WebApi;

public class Middleware
{
    private readonly RequestDelegate _next;

    public Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var logFilePath = "logs.txt";

        var requestHeaders = context.Request.Headers;
        using (var writer = new StreamWriter(logFilePath, true, Encoding.UTF8))
        {
            await writer.WriteLineAsync("Request Header:");
            foreach (var header in requestHeaders)
            {
                await writer.WriteLineAsync($"{header.Key}: {header.Value}");
            }
            await writer.WriteLineAsync();
        }
        await _next(context);

        var responseHeaders = context.Response.Headers;
        using (var writer = new StreamWriter(logFilePath, true, Encoding.UTF8))
        {
            await writer.WriteLineAsync("Response Header:");
            foreach (var header in responseHeaders)
            {
                await writer.WriteLineAsync($"{header.Key}: {header.Value}");
            }
            await writer.WriteLineAsync();
        }
    }
}
