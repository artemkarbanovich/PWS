using lab_1.Exceptions;
using lab_1.Models;
using System.Web;

namespace lab_1.HttpVerbHandlers
{
    public class ResultInvalidVerbHandler : IHandler
    {
        public ResultInvalidVerbHandler(HttpContext context)
        {
            Context = context;
        }

        public HttpContext Context { get; set; }

        public void Handle(Result result = null)
        {
            try
            {
                throw new InvalidVerbException($"Verb {Context.Request.HttpMethod} not supported", Context);
            }
            catch(InvalidVerbException ex)
            {
                ex.HandleException();
            }
        }
    }
}
