using ASP.NET.Views.Main;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection;
using System.Text;

public class MainController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

   
}