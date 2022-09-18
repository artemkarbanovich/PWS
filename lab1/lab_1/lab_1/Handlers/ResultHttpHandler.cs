using lab_1.HttpVerbHandlers;
using lab_1.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace lab_1.Handlers
{
    public class ResultHttpHandler : IHttpHandler, IRequiresSessionState
    {
        private static readonly Lazy<Result> Result = new Lazy<Result>();

        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["stack"] == null)
                context.Session["stack"] = new Stack<int>();

            switch (context.Request.HttpMethod)
            {
                case "GET": new ResultGetHandler(context).Handle(Result.Value); break;
                case "POST": new ResultPostHandler(context).Handle(Result.Value); break;
                case "PUT": new ResultPutHandler(context).Handle(); break;
                case "DELETE": new ResultDeleteHandler(context).Handle(); break;
                default: new ResultInvalidVerbHandler(context).Handle(); break;
            }
        }
    }
}
