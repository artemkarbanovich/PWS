using Lab4.Extensions;
using Lab4.Models;
using System.Diagnostics;
using System.Web.Script.Services;
using System.Web.Services;

namespace Lab4
{
    [WebService(Namespace = "http://kak/", Description = "Simplex Web Service ASMX")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class Simplex : WebService
    {
        [WebMethod(Description = "returns sum of integer 'x' and 'y'", MessageName = "AddMessageName")]
        public int Add(int x, int y)
        {
            Debug.WriteLine(this.ParseBody(Context.Request));
            return x + y;
        }

        [WebMethod(Description = "returns sum of integer 'x' and 'y'", MessageName = "AddSMessageName")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int AddS(int x, int y)
        {
            return x + y;
        }

        [WebMethod(Description = "returns concatenation of string 's' and real number 'd'", MessageName = "ConcatMessageName")]
        public string Concat(string s, double d)
        {
            Debug.WriteLine(this.ParseBody(Context.Request));
            return $"{s}{d}";
        }

        [WebMethod(Description = "returns sum/concatenation of each field from request objects", MessageName = "SumMessageName")]
        public A Sum(A a1, A a2)
        {
            Debug.WriteLine(this.ParseBody(Context.Request));
            return a1 + a2;
        }
    }
}
