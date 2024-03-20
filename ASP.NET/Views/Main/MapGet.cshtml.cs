using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.Views.Main
{
    public class MapGetModel : PageModel
    {
        public string API_KEY_JS_GOOGLE_MAP { get;set; }
        public void OnGet()
        {
        }
    }
}
