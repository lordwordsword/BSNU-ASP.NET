using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.Views.Main
{
    public class MapPostModel : PageModel
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
        public void OnGet()
        {
        }
    }
}
