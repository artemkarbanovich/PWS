using lab_1.Exceptions;
using lab_1.Models;
using System.Collections.Generic;
using System.Web;

namespace lab_1.HttpVerbHandlers
{
    public class ResultPutHandler : IHandler
    {
        public ResultPutHandler(HttpContext context)
        {
            Context = context;
        }

        public HttpContext Context { get; set; }

        public void Handle(Result result = null)
        {
            try
            {
                if (int.TryParse(Context.Request.Params["add"], out var addParam))
                    (Context.Session["stack"] as Stack<int>).Push(addParam);
                else
                    throw new InvalidParamException("Invalid add's param", Context);
            }
            catch (InvalidParamException ex)
            {
                ex.HandleException();
            }
        }
    }
}
