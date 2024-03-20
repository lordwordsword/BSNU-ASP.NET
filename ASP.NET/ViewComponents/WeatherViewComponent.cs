using dotenv;
using Microsoft.AspNetCore.Mvc;


public class WeatherViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(string lat, string lng)
    {
        dotenv.net.DotEnv.Load();

        var api_key = Environment.GetEnvironmentVariable("API_KEY_WEATHER");
        var model = new ASP.NET.Views.Components.Weather.DefaultModel
        {
            API_KEY_WEATHER = api_key,
            Lat = lat,
            Lng = lng
        };

        return View("Weather", model); 
    }
}

