using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Preezie.Solution.ExceptionHandler.CustomExceptions
{
    public class NotFoundException : ExceptionBase
    {
        private const int STATUS_CODE = StatusCodes.Status404NotFound;
        private const string DEFAULT_MESSAGE = "We could not find what you were looking for.";

        public NotFoundException() : base(STATUS_CODE, DEFAULT_MESSAGE)
        {
        }
        public NotFoundException(string message) : base(STATUS_CODE, DEFAULT_MESSAGE, message)
        {
        }
        public NotFoundException(string message, Exception innerException) : base(STATUS_CODE, DEFAULT_MESSAGE, message, innerException)
        {
        }
        public NotFoundException(string message, string[] errors) : base(STATUS_CODE, DEFAULT_MESSAGE, message, errors)
        {
        }

        public NotFoundException(ModelStateDictionary modelState) : base(STATUS_CODE, DEFAULT_MESSAGE)
        {
            Errors = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();
        }
    }
}
