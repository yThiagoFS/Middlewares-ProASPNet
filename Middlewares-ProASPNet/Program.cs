using Microsoft.Extensions.Options;
using Middlewares_ProASPNet.Platform;
using static Middlewares_ProASPNet.Platform.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MessageOptions>(options =>
{
    options.CityName = "Albany";
});

var app = builder.Build();

//Location middleware
//app.MapGet("/location", async (HttpContext context, IOptions<MessageOptions> msgOpts) =>
//{
//    MessageOptions opts = msgOpts.Value;
//    await context.Response.WriteAsync($"{opts.CityName}, {opts.CountryName}");
//});

//Location middleware class-based
app.UseMiddleware<LocationMiddleware>();

app.MapGet("/", () => "Hello World");

app.Run();