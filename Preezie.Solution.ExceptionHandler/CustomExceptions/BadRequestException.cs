using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Preezie.Solution.ExceptionHandler.CustomExceptions
{
    public class BadRequestException : ExceptionBase
    {
        private const int STATUS_CODE = StatusCodes.Status400BadRequest;
        private const string DEFAULT_MESSAGE = "Bad Request";

        public BadRequestException() : base(STATUS_CODE, DEFAULT_MESSAGE)
        {
        }
        public BadRequestException(string message) : base(STATUS_CODE, DEFAULT_MESSAGE, message)
        {
        }
        public BadRequestException(string message, Exception innerException) : base(STATUS_CODE, DEFAULT_MESSAGE, message, innerException)
        {
        }
        public BadRequestException(string message, string[] errors) : base(STATUS_CODE, DEFAULT_MESSAGE, message, errors)
        {
        }

        public BadRequestException(ModelStateDictionary modelState) : base(STATUS_CODE, DEFAULT_MESSAGE)
        {
            Errors = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();
        }
    }
}
