using System.IO;
using System.Web;
using System.Web.Services;

namespace Lab4.Extensions
{
    public static class WebServiceExtensions
    {
        public static string ParseBody(this WebService webService, HttpRequest request)
        {
            request.InputStream.Position = 0;
            var body = string.Empty;

            using (Stream receiveStream = request.InputStream)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, true))
                {
                    body = readStream.ReadToEnd();
                }
            }

            return body;
        }
    }
}