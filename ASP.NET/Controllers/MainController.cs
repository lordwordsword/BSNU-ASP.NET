﻿using ASP.NET.Views.Main;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

public class MainController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        return RedirectToAction("MapGet", "Main");
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


    [HttpGet]
    [Route("Map")]
    public IActionResult MapGet()
    {
        dotenv.net.DotEnv.Load();

        var api_key = Environment.GetEnvironmentVariable("API_KEY_JS_GOOGLE_MAP");
        var model = new MapGetModel
        {
            API_KEY_JS_GOOGLE_MAP = api_key,
        };

        return View(model);
    }

    [HttpPost]
    [Route("Map")]
    public IActionResult MapPost(string lat, string lng)
    {
        var model = new MapPostModel
        {
            Lat = lat,
            Lng = lng
        };

        return View(model);
    }
}