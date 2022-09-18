using System.Web;

namespace lab_1.Exceptions
{
    public interface IHttpException
    {
        HttpContext Context { get; set; }
        void HandleException();
    }
}
