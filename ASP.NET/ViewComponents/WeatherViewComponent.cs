
using ASP.NET.Views.Components.Weather;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;

public class WeatherViewComponent : ViewComponent
{
    static async Task<dynamic> FetchWeatherData(string latitude, string longitude, string apiKey)
    {
        try
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(
                    $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}"
                );
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();

                dynamic data = JsonConvert.DeserializeObject(jsonString);
                return data;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }

    public async Task<IViewComponentResult> InvokeAsync(string lat, string lng)
    {
        dotenv.net.DotEnv.Load();
        var api_key = Environment.GetEnvironmentVariable("API_KEY_WEATHER");

        dynamic weatherData = await FetchWeatherData(lat, lng, api_key);

        double tempCelsius = Math.Round((double)weatherData.main.temp - 273.15);
        double pressure = (double)weatherData.main.pressure;
        int humidity = (int)weatherData.main.humidity;
        double windSpeed = (double)weatherData.wind.speed;

        var model = new WeatherModel
        {
            TempCelsius = tempCelsius,
            Pressure = pressure,
            Humidity = humidity,
            WindSpeed = windSpeed,
        };

        return View("Weather", model); 
    }
}

