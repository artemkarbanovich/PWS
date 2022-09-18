using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace StudentsApp.Responses
{
    public class Error : Response<object>
    {
        [DataMember]
        public int ErrorCode { get; set; }
        
        [DataMember]
        public List<LinkResponse> Links { get; set; } = new List<LinkResponse>();

        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) => Task.Run(() =>
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new ObjectContent(GetType(), this, Formatter) };
        }, cancellationToken);
    }
}