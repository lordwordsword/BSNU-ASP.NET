using Microsoft.AspNetCore.Mvc;
using System.Reflection;


public class TableViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(List<Product> products)
    {
        return View("Table", products);
    }
}
