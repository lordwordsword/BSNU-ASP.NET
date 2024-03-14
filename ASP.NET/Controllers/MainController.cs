using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

public class MainController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        return RedirectToAction("AddProduct", "Main");
    }

    [HttpGet]
    [Route("AddProduct")]
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    [Route("AddProduct")]
    public IActionResult AddProductPut(string name, string price)
    {
        bool result = false;
        try
        {
            Product product = new Product(name, decimal.Parse(price, CultureInfo.InvariantCulture), DateTime.Now);
            result = ProductRepository.AddProduct(product);
        }
        catch{}
        TempData["Status"] = result;
        return View("AddProduct");
    }

    [HttpGet]
    [HttpPost]
    [Route("ProductView")]
    public IActionResult ProductView(string? mode)
    {
        if (mode == null)
        {
            TempData["mode"] = "list";
        }
        else
        {
            TempData["mode"] = mode;
            
        }
        TempData["Products"] = ProductRepository.GetProductList();
        return View();
    }

}