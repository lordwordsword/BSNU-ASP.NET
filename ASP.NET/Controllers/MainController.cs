using ASP.NET.Views.Main;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection;
using System.Text;

public class MainController : Controller
{
    [HttpGet]

    public IActionResult MakeAnAppointment()
    {
        return View();
    }

    [HttpPost]

    public IActionResult MakeAnAppointment(ConsultationRequest model)

    {
        Console.WriteLine("Model state: " + ModelState.IsValid);
        Console.WriteLine("Model data: " + model.FullName + ", " + model.Email + ", " + model.ConsultationDate + ", " + model.Type);
        if (ModelState.IsValid)
        {
            return View("Success", model);
        }
        return View(model);
    }


    public IActionResult Success(ConsultationRequest model)
    {
        return View(model);
    }
}