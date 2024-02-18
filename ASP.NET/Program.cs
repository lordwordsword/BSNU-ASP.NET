
using System;
using ASP.NET.interfaces;
using ASP.NET.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICalcService, CalcService>().AddTransient<ITimeAnalyzer, TimeAnalyzer>();
var app = builder.Build();

app.MapGet("/1/", async context =>
{
    var calcService = app.Services.GetService<ICalcService>();
    await context.Response.WriteAsync($"Result of addition: {calcService?.Add(1, 2)}\n");
    await context.Response.WriteAsync($"Result of multiplication: {calcService?.Multiply(1f, 2f)}\n");
    await context.Response.WriteAsync($"Result of subtraction: {calcService?.Subtract(1, 2)}\n");
    await context.Response.WriteAsync($"Result of division: {calcService?.Divide(1.0, 2.0)}\n");
});

app.MapGet("/2/", async context =>
{
    var dayTimeService = app.Services.GetService<ITimeAnalyzer>();
    await context.Response.WriteAsync($"Current time of the day: {dayTimeService?.GetTimeOfDay(DateTime.Now)}\n");
});

app.Run();
