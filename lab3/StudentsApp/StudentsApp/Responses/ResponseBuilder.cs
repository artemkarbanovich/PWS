using System.Net.Http.Formatting;

namespace StudentsApp.Responses
{
    public abstract class ResponseBuilder<T>
    {
        public static SuccessBuilder<T> Success(T obj) => new SuccessBuilder<T>(obj);
        public static ErrorBuilder Error(int errorCode) => new ErrorBuilder(errorCode);
        public abstract ResponseBuilder<T> Formatter(MediaTypeFormatter mediaTypeFormatter);
        public abstract ResponseBuilder<T> AddLink(LinkResponse link);
        public abstract Response<T> Create();
    }
}