using ASP.NET.Views.Main;
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
        if (db.Users.ToList().Count == 0)
        {
            db.Users.Add(new User
            {
                FirstName = "D",
                LastName = "Step",
                Age = 20
            });
            db.Users.Add(new User
            {
                FirstName = "Sample",
                LastName = "Text",
                Age = 1
            });
            db.Users.Add(new User
            {
                FirstName = "idk",
                LastName = "lol",
                Age = 90
            });
        }
        if (db.Companies.ToList().Count == 0)
        {
            db.Companies.Add(new Company
            {
                Name = "Google",
                Employees = 500
            });
            db.Companies.Add(new Company
            {
                Name = "Apple",
                Employees = 200
            });
            db.Companies.Add(new Company
            {
                Name = "Amazon",
                Employees = 300
            });
        }
        await db.SaveChangesAsync();
        return View(new IndexModel
        {
            Users = await db.Users.ToListAsync(),
            Companies = await db.Companies.ToListAsync()
        });
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

    public async Task<IActionResult> Edit(int? id)

    {

        if (id != null)

        {

            User? user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);

            if (user != null) return View(user);

        }

        return NotFound();

    }

    [HttpPost]
    public async Task<IActionResult> Edit(User user)
    {
        // Проверяем состояние модели
        if (!ModelState.IsValid)
        {
            // Если модель не прошла валидацию, возвращаем представление редактирования с ошибками
            return View(user);
        }

        // Обновляем состояние объекта user в контексте базы данных
        db.Entry(user).State = EntityState.Modified;

        try
        {
            // Сохраняем изменения
            await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            // Обработка исключения при одновременном обновлении данных другим пользователем
            throw;
        }

        // Перенаправляем пользователя на страницу Index
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null)
        {
            User? user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user != null)
            {
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        return NotFound();
    }
}