using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace project.ActionFilters
{
    //this is gonna run if there any exception happened in any action of the student class
    public class StudentClassException:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ContentResult() { Content = "Student Class Exception" };
            }
            base.OnActionExecuted(context);
        }
    }
}
