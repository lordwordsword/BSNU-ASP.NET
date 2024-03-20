using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.Views.Components.Weather
{
    public class WeatherModel : PageModel
    {
        public string Lat {  get; set; }
        public string Lng { get; set; }
        public string API_KEY_WEATHER { get; set; }
        public void OnGet()
        {
        }
    }
}
