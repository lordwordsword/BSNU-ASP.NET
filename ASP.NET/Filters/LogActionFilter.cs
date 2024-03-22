using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
public class LogActionFilter : ActionFilterAttribute
{
    override public void OnActionExecuting(ActionExecutingContext context)
    {
        var controllerName = context.ActionDescriptor.DisplayName;
        var methodName = context.ActionDescriptor.DisplayName;
        var currentTime = DateTime.Now;

        var logEntry = new
        {
            ControllerName = controllerName,
            MethodName = methodName,
            Timestamp = currentTime
        };

        var logJson = JsonConvert.SerializeObject(logEntry);
        File.AppendAllText("log.json", logJson + Environment.NewLine);
    }
}

