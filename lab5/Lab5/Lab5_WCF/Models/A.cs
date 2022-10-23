using System.Runtime.Serialization;

namespace Lab5_WCF.Models
{
    [DataContract]
    public class A
    {
        [DataMember]
        public string S { get; set; }
        
        [DataMember]
        public int K { get; set; }

        [DataMember]
        public float F { get; set; }

        public static A operator +(A a1, A a2) => new A
        {
            S = $"{a1.S}{a2.S}",
            K = a1.K + a2.K,
            F = a1.F + a2.F,
        };
    }
}
