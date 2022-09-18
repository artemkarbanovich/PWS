using System.Net.Http.Formatting;

namespace StudentsApp.Responses
{
    public class ErrorBuilder : ResponseBuilder<object>
    {
        private readonly Error _error;

        public ErrorBuilder(int errorCode) => _error = new Error { ErrorCode = errorCode };

        public override ResponseBuilder<object> Formatter(MediaTypeFormatter mediaTypeFormatter)
        {
            _error.Formatter = mediaTypeFormatter;
            return this;
        }

        public override ResponseBuilder<object> AddLink(LinkResponse link)
        {
            _error.Links.Add(link);
            return this;
        }

        public override Response<object> Create() => _error;
    }
}