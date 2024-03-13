using Microsoft.AspNetCore.Mvc;
using System.Text;

public class FileController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        return RedirectToAction("DownloadFile", "File");
    }
    [HttpGet]
    [Route("DownloadFile")]
    public IActionResult DownloadFile()
    {
        return View();
    }

    [HttpPost]
    [Route("DownloadFile")]
    public IActionResult DownloadFilePut(string fileName, string firstName, string lastName, string? fileContent)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(firstName).Append("\n").Append(lastName).Append("\n");
            if (fileContent != null) 
                stringBuilder.Append(fileContent); 
            
            FileUtils.GenerateFile(ms, stringBuilder.ToString());

            ms.Position = 0;

            string contentType = "text/plain";

            return File(ms.ToArray(), contentType, FileUtils.RemoveInvalidFileNameChars(fileName +".txt"));
        }
    }

   
    
}