using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection;
using System.Text;

public class MainController : Controller
{
    ApplicationContext db;
    public MainController(ApplicationContext context)
    {
        db = context;
    }


    public async Task<IActionResult> Index()
    {
        return View(await db.Users.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        Console.WriteLine(user.FirstName + " " + user.LastName + " " + user.Age);
        db.Users.Add(user);
        
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
    }


}