using Microsoft.AspNetCore.Mvc;

public class MainController : Controller
{
    [HttpGet]
    [Route("ProductSelection")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("ProductCountSelection")]
    public IActionResult ProductCountSelection()
    {  
        return RedirectToAction("Index", "Main");
    }

   
    
}