using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("me.json");
int k = 0;
foreach (string filename in new List<string>() { ".\\ini1.ini", ".\\json1.json", ".\\XMLFile1.xml" })
{
    var config = Utils.LoadConfiguration(filename);
    Company company = config.GetSection("Company").Get<Company>();

    builder.Configuration[$"Companies:{k}:name"] = company.Name;
    builder.Configuration[$"Companies:{k}:employees"] = company.Employees.ToString();

    //Я не знайшов способу зробити це без явного вказання властивостей класу
    //і взагалі не впевнений що такий спосіб є, але, якщо він існує, можете 
    //надіслати код у відповіді до роботи чи будь-яким іншим зручним для вас способом?

    k++;
}
var app = builder.Build();

app.MapGet("/", () =>
{
    var name = builder.Configuration.GetSection("name").Get<string>();
    var surname = builder.Configuration.GetSection("surname").Get<string>();
    var age = builder.Configuration.GetSection("age").Get<int>();
    var group = builder.Configuration.GetSection("group").Get<int>();
    return $"name:{name}\nsurname:{surname}\nage:{age}\ngroup:{group}\n";
});
app.MapGet("/1/", () => Utils.CompanyWithTheMostEmployees(builder.Configuration, k));
app.Run();
