var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
Company company = new Company();
Random random = new Random();

company.Name = "Microsoft";
company.Employyes = 2001;
app.MapGet("/1/", () => company.Name +"\n"+ company.Employyes.ToString());
app.MapGet("/2/", () => random.Next(101));
app.Run();
