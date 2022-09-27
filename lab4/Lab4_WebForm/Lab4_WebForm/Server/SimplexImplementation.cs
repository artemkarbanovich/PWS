using System.Xml.Serialization;

namespace Lab4_WebForm.Server
{
    public class SimplexImplementation : Simplex
    {
        [return: XmlElement("AddMessageNameResult")]
        public override int Add(int x, int y)
        {
            return x + y;
        }

        [return: XmlElement("AddSMessageNameResult")]
        public override int AddS(int x, int y)
        {
            return x + y;
        }

        [return: XmlElement("ConcatMessageNameResult")]
        public override string Concat(string s, double d)
        {
            return $"{s}{d}";
        }

        [return: XmlElement("SumMessageNameResult")]
        public override A Sum(A a1, A a2)
        {
            return a1 + a2;
        }
    }
}