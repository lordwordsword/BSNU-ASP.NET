using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("cfg.json");

Library? library = builder.Configuration.GetSection("Library").Get<Library>() ;

var app = builder.Build();
app.MapGet("/", async context => context.Response.Redirect("/library"));
app.MapGet("/library", () => "Hello, user!");
app.MapGet("/library/books", () => {
    StringBuilder stringBuilder = new StringBuilder();
    if (library != null)
    {
        foreach (var book in library.books)
        {
            stringBuilder.Append($"Title: {book.Title}.\nAuthor: {book.Author}.\n\n");
        }
    }
    return stringBuilder.ToString();
});
app.MapGet("/library/profile/{id?}", (int? id) =>
{
    Profile profile = new Profile();

    if (library != null && id != null)
    {
        profile = library.profiles[(int)id];
    }
    if (profile != null) { 
        return $"Profile name: {profile.Name}.\nProfile surname: {profile.Surname}.";
    }
    return "";

});

app.Run();