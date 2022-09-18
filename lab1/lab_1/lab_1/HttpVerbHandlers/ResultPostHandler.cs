using lab_1.Exceptions;
using lab_1.Models;
using System.Web;

namespace lab_1.HttpVerbHandlers
{
    public class ResultPostHandler : IHandler
    {
        public ResultPostHandler(HttpContext context)
        {
            Context = context;
        }

        public HttpContext Context { get; set; }

        public void Handle(Result result)
        {
            try
            {
                if (int.TryParse(Context.Request.Params["result"], out var resultParam))
                    result.Value = resultParam;
                else
                    throw new InvalidParamException("Invalid result's param", Context);
            }
            catch(InvalidParamException ex)
            {
                ex.HandleException();
            }
        }
    }
}
