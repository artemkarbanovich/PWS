using lab_1.Models;
using lab_1.Responses;
using System.Collections.Generic;
using System.Web;

namespace lab_1.HttpVerbHandlers
{
    public class ResultGetHandler : IHandler
    {
        public ResultGetHandler (HttpContext context)
        {
            Context = context;
        }

        public HttpContext Context { get; set; }

        public void Handle(Result result)
        {
            var stack = Context.Session["stack"] as Stack<int>;

            Context.Response.Write(new JsonResponse(result: (result.Value + (stack.Count != 0 ? stack.Peek() : 0)).ToString()));
        }
    }
}
