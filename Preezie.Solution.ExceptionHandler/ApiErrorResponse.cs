using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Preezie.Solution.ExceptionHandler.CustomExceptions;

namespace Preezie.Solution.ExceptionHandler
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public object Payload { get; set; }
        public string TraceId { get; set; }

        private ApiErrorResponse()
        {
        }

        public static ObjectResult Response(Exception ex, string traceIdentifier)
        {
            var response = new ApiErrorResponse();
            response.TraceId = traceIdentifier;

            if (ex is ExceptionBase)
            {
                var customEx = (ExceptionBase)ex;
                response.StatusCode = customEx.StatusCode;
                response.Message = customEx.Message ?? customEx.DefaultMessage;
                response.Errors = customEx.Errors;
                response.Payload = customEx.Payload;
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Message = "A server side error occurred. Contact your administrator for more information";
                //you should log unkown exception messages or send them to yourself via email etc for further investigations.
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}