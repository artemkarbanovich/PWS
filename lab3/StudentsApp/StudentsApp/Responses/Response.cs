using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Serialization;

namespace StudentsApp.Responses
{
    [DataContract]
    [KnownType(typeof(Error))]
    [KnownType(typeof(Success<StudentResponse>))]
    [KnownType(typeof(Success<List<StudentResponse>>))]
    [KnownType(typeof(Success<List<Success<StudentResponse>>>))]
    public abstract class Response<T> : IHttpActionResult
    {
        [IgnoreDataMember]
        [XmlIgnore]
        public MediaTypeFormatter Formatter { protected get; set; } = new JsonMediaTypeFormatter();

        public abstract Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken);
    }
}