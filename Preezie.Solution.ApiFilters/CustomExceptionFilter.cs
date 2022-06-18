using Microsoft.AspNetCore.Mvc.Filters;
using Preezie.Solution.ExceptionHandler;

namespace Preezie.Solution.ApiFilters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = ApiErrorResponse.Response(context.Exception, context.HttpContext.TraceIdentifier);
            context.ExceptionHandled = true;
        }
    }
}