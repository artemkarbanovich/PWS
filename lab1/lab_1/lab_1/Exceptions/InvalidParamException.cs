using lab_1.Responses;
using System;
using System.Web;

namespace lab_1.Exceptions
{
    public class InvalidParamException : Exception, IHttpException
    {
        public InvalidParamException(string message, HttpContext context) : base(message) 
        {
            Context = context;
        }

        public HttpContext Context { get; set; }

        public void HandleException() => Context.Response.Write(new JsonResponse(error: Message));
    }
}
