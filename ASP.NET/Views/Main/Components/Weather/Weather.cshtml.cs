using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.Views.Components.Weather
{
    public class WeatherModel : PageModel
    {
        public double TempCelsius {  get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public void OnGet()
        {
        }
    }
}
