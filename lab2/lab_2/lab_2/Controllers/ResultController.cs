using lab_2.Models;
using lab_2.Responses;
using System.Collections.Generic;
using System.Web.Http;

namespace lab_2.Controllers
{
    public class ResultController : ApiController
    {
        private static readonly Stack<int> _stack = new Stack<int>();
        private static readonly Result _result = new Result();

        [HttpGet]
        public IHttpActionResult Get() => Ok(new JsonResponse<int>(_result.Value + (_stack.Count != 0 ? _stack.Peek() : 0)));

        [HttpPost]
        public void Post([FromUri] int result) => _result.Value = result;

        [HttpPut]
        public void Put([FromUri] int add) => _stack.Push(add);

        [HttpDelete]
        public void Delete()
        {
            if (_stack.Count != 0) _stack.Pop();
        }
    }
}
