using Microsoft.AspNetCore.Mvc;

public class MainController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [Route("ProductCountSelection")]
    public IActionResult ProductCountSelection(User user)
    {      
        if (user.Age > 16)
        {
            return View();
        }
        return RedirectToAction("Index", "Main");
    }

    [HttpPost]
    [Route("ProductSelection")]
    public IActionResult ProductSelection(int count)
    {
        if (count > 0)
        {
            TempData["Count"] = count;


            ;
            TempData["ProductNames"] = ProductRepository.Products.ToList();

            return View();
        }
        else
        {
            return RedirectToAction("Index", "Main");
        }
    }

    [HttpPost]
    [Route("Result")]
    public IActionResult Result(ProductAmount[] productAmounts)
    {
        decimal total = 0;
        if (productAmounts is not null)
        {
            foreach (var productAmount in productAmounts)
            {
                Product? product = ProductRepository.Products.ToList().Find(x => x.Name == productAmount.Product.Name);
                    if (product is not null) { 
                    total += product.Price * productAmount.Amount;
                }
            }
            TempData["Total"] = total;

            return View();
        }
        return RedirectToAction("Index", "Main");
    }
}