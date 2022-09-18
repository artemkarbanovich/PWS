using System.Runtime.Serialization;

namespace StudentsApp.Responses
{
    [DataContract]
    public class LinkResponse
    {
        public LinkResponse(string rel, string url, string type)
        {
            Rel = rel;
            Url = url;
            Type = type;
        }

        public LinkResponse() { }

        [DataMember]
        public string Rel { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string Type { get; set; }
    }
}