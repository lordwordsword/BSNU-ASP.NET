var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(LogActionFilter));
    options.Filters.Add(new UniqueUsersFilter("Users.txt"));
});
var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "",
    defaults: new { controller = "Main", action = "Index" });

app.Run();