using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Preezie.Solution.ExceptionHandler
{
    public class ExceptionBase : Exception
    {
        public string[] Errors { get; set; }
        public object Payload { get; set; }
        public int StatusCode { get; set; }
        public string DefaultMessage { get; set; }

        public ExceptionBase(int statusCode, string defaultMessage) : base()
        {
            StatusCode = statusCode;
            DefaultMessage = defaultMessage;
        }

        public ExceptionBase(int statusCode, string defaultMessage, string message) : base(message)
        {
            StatusCode = statusCode;
            DefaultMessage = defaultMessage;
        }

        public ExceptionBase(int statusCode, string defaultMessage, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
            DefaultMessage = defaultMessage;
        }

        public ExceptionBase(int statusCode, string defaultMessage, string message, string[] errors) : base(message)
        {
            StatusCode = statusCode;
            DefaultMessage = defaultMessage;
            Errors = errors;
        }

        public ExceptionBase(int statusCode, string defaultMessage, string message, string[] errors, object payload) : base(message)
        {
            StatusCode = statusCode;
            DefaultMessage = defaultMessage;
            Errors = errors;
            Payload = payload;
        }
    }
}