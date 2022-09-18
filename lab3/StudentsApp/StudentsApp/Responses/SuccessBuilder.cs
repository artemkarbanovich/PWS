using System.Net.Http.Formatting;

namespace StudentsApp.Responses
{
    public class SuccessBuilder<T> : ResponseBuilder<T>
    {
        private readonly Success<T> _success;

        public SuccessBuilder(T obj) => _success = new Success<T> { Result = obj };

        public override ResponseBuilder<T> Formatter(MediaTypeFormatter mediaTypeFormatter)
        {
            _success.Formatter = mediaTypeFormatter;
            return this;
        }

        public override ResponseBuilder<T> AddLink(LinkResponse link)
        {
            _success.Links.Add(link);
            return this;
        }

        public override Response<T> Create() => _success;
    }
}