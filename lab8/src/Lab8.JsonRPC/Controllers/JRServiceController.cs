using lab8.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace lab8.Controllers
{
    public class JRServiceController : ApiController, IRequiresSessionState
    {
        [HttpPost]
        [Route("api/JRService/Multi")]
        public IHttpActionResult Multi([FromBody] JsonRpcReq[] body)
        {
            var length = body.Length;
            var result = new List<JsonRpcResp>();

            for (var i = 0; i < length; i++)
            {
                if (string.IsNullOrWhiteSpace(body[i].id))
                {
                    Process(body[i]);
                    continue;
                }
                result.Add(Process(body[i]));
            }
            return Json(result, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        [HttpPost]
        [Route("api/JRService/Single")]
        public IHttpActionResult Single([FromBody] JsonRpcReq body)
        {
            var result = Process(body);
            return string.IsNullOrWhiteSpace(body.id) 
                ? (IHttpActionResult) StatusCode(System.Net.HttpStatusCode.Accepted) 
                : Json(result, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        private JsonRpcResp Process(JsonRpcReq jsonRpcReq)
        {
            bool? isError = (bool?)HttpContext.Current.Session["error"];
            if (isError ?? false)
                return new JsonRpcResp(new InternalErrorJsonRPC());

            string method;
            DataModel param;
            string key;
            
            try
            {
                method = jsonRpcReq.method;
                param = jsonRpcReq.@params;
                key = param.key;
            }
            catch
            {
                return new JsonRpcResp(new InvalidRequestErrorJsonRPC());
            }

            if (method == "ErrorExit")
            {
                ErrorExit();
                return new JsonRpcResp(new InternalErrorJsonRPC());
            }

            if (key == null)
                return new JsonRpcResp(new InvalidParamsErrorJsonRPC("Invalid key"), jsonRpcReq.id);

            int? result;
            try
            {
                switch (method)
                {
                    case "SetM":
                        {
                            result = SetM(key, int.Parse(param.value));
                            break;
                        }
                    case "GetM":
                        {
                            result = GetM(key);
                            break;
                        }
                    case "AddM":
                        {
                            result = AddM(key, int.Parse(param.value));
                            break;
                        }
                    case "SubM":
                        {
                            result = SubM(key, int.Parse(param.value));
                            break;
                        }
                    case "MulM":
                        {
                            result = MulM(key, int.Parse(param.value));
                            break;
                        }
                    case "DivM":
                        {
                            result = DivM(key, int.Parse(param.value));
                            break;
                        }
                    default:
                        {
                            return new JsonRpcResp(new MethodNotFoundErrorJsonRPC(), jsonRpcReq.id);
                        }
                }
            }
            catch (ArgumentNullException)
            {
                return new JsonRpcResp(new InvalidParamsErrorJsonRPC("Invalid value"), jsonRpcReq.id);
            }
            catch (FormatException)
            {
                return new JsonRpcResp(new InvalidParamsErrorJsonRPC("Invalid value"), jsonRpcReq.id);
            }
            catch (OverflowException)
            {
                return new JsonRpcResp(new InvalidParamsErrorJsonRPC("Invalid value"), jsonRpcReq.id);
            }
            catch
            {
                return new JsonRpcResp(new ServerErrorJsonRPC(), jsonRpcReq.id);
            }
            return new JsonRpcResp(result, jsonRpcReq.id);
        }

        private int SetM(string k, int x)
        {
            HttpContext.Current.Session[k] = x;
            return (int)GetM(k);
        }

        private int? GetM(string k)
        {
            object result = HttpContext.Current.Session[k];
            if (result == null)
                throw new ArgumentNullException();

            return int.Parse(result.ToString());
        }

        private int AddM(string k, int x) => SetM(k, (int)(GetM(k) + x));

        private int SubM(string k, int x) => SetM(k, (int)(GetM(k) - x));

        private int MulM(string k, int x) => SetM(k, (int)(GetM(k) * x));

        private int DivM(string k, int x) => SetM(k, (int)(GetM(k) / x));

        private void ErrorExit()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session["error"] = true;
        }
    }
}
