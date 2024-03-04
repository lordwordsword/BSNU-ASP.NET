using Microsoft.Extensions.Logging;




var builder = WebApplication.CreateBuilder(args);


builder.Logging.AddFile($"logs/myapp-{DateTime.UtcNow}.txt".Replace(":", "_"), LogLevel.Error);


//.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt")));
var app = builder.Build();

app.MapGet("/", async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.MapPost("/check-cookies", async (context) =>
{
   

    try
    {
        var form = await context.Request.ReadFormAsync();

        var name = form["name"];
        var dateTime = form["datetime"];
        throw new InvalidOperationException("This is a test exception");

        if (context.Request.Cookies.ContainsKey("name"))
        {
            await context.Response.WriteAsync($"Hello {name}!");
        }
        else
        {
            context.Response.Cookies.Append("name", name, new CookieOptions
            {
                Expires = Convert.ToDateTime(dateTime)
            });

            await context.Response.WriteAsync("Hello World!");
        }
    }
    catch (InvalidOperationException ex)
    {
        var path = context.Request.Path;
        app.Logger.LogError($"{path}\n{ex.Message}\n{ex.Data}\n{ex.Source}\n\n");
    }
});

app.Run();

