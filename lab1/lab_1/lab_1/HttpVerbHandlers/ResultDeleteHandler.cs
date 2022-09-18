using lab_1.Models;
using System.Collections.Generic;
using System.Web;

namespace lab_1.HttpVerbHandlers
{
    public class ResultDeleteHandler : IHandler
    {
        public ResultDeleteHandler(HttpContext context)
        {
            Context = context;
        }

        public HttpContext Context { get; set; }

        public void Handle(Result result = null)
        {
            var stack = Context.Session["stack"] as Stack<int>;

            if (stack.Count != 0) stack.Pop();
        }
    }
}
