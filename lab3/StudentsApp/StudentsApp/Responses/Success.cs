using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Threading;

namespace StudentsApp.Responses
{
    public class Success<T> : Response<T>
    {
        [DataMember]
        public T Result { get; set; }

        [DataMember]
        public List<LinkResponse> Links { get; set; } = new List<LinkResponse>();
        
        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken) => Task.Run(() =>
        {
            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ObjectContent(typeof(Success<T>), this, Formatter) };
        }, cancellationToken);
    }
}