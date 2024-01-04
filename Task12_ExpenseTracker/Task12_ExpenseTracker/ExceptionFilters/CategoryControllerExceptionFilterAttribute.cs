using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Task12_ExpenseTracker.ExceptionFilters
{
    public class CategoryControllerExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionMessage = context.Exception.Message;

            var errorResponse = new
            {
                message = $"An internal server error occurred in {actionName}",
                errorMessage = exceptionMessage
            };

            context.Result = new JsonResult(errorResponse)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
