namespace Lab4.Models
{
    public class A
    {
        public string S { get; set; }
        public int K { get; set; }
        public float F { get; set; }

        public static A operator + (A a1, A a2) => new A { S = $"{a1}{a2}", K = a1.K + a2.K, F = a1.F + a2.F };

        public override string ToString() => S;
    }
}