using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace project.ActionFilters
{
    public class CreatesStudentException:ActionFilterAttribute
    {
        //before the exception is raised
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        //after the exception raised
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ContentResult() { Content = "Contact Admin" };
            }
                base.OnActionExecuted(context);
        }

    }
}
