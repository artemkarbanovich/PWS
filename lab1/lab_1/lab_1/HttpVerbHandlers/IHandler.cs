using lab_1.Models;
using System.Web;

namespace lab_1.HttpVerbHandlers
{
    public interface IHandler
    {
        HttpContext Context { get; set; }
        void Handle(Result result);
    }
}
