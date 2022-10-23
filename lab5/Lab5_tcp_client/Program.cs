using Lab5_tcp_client.SiplexService;
using System;

namespace Lab5_tcp_client
{
    public class Program
    {
        private static readonly WCFSiplexClient _connection = new WCFSiplexClient("tcp");

        static void Main()
        {
            Console.Write("TCP CLIENT\n");
            string input = string.Empty;

            while (input != "0")
            {
                Console.Write("\n\t0 - exit\n\t1 - add\n\t2 - concat\n\t3 - sum\nCode: ");
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        {
                            continue;
                        }
                    case "1":
                        {
                            Console.Write("x = ");
                            var x = Console.ReadLine();

                            Console.Write("y = ");
                            var y = Console.ReadLine();

                            if (int.TryParse(x, out var xVal) && int.TryParse(y, out var yVal))
                            {
                                var response = _connection.Add(xVal, yVal);
                                Console.WriteLine($"x + y = {response}");
                            }
                            else
                            {
                                Console.WriteLine("Check inputs");
                            }

                            break;
                        }
                    case "2":
                        {
                            Console.Write("s = ");
                            var s = Console.ReadLine();

                            Console.Write("d = ");
                            var d = Console.ReadLine();

                            if (double.TryParse(d, out var dVal))
                            {
                                var response = _connection.Concat(s, dVal);
                                Console.WriteLine($"x + y = {response}");
                            }
                            else
                            {
                                Console.WriteLine("Check inputs");
                            }

                            break;
                        }
                    case "3":
                        {
                            Console.Write("s1 = ");
                            var s1 = Console.ReadLine();

                            Console.Write("s2 = ");
                            var s2 = Console.ReadLine();

                            Console.Write("k1 = ");
                            var k1 = Console.ReadLine();

                            Console.Write("k2 = ");
                            var k2 = Console.ReadLine();

                            Console.Write("f1 = ");
                            var f1 = Console.ReadLine();

                            Console.Write("f2 = ");
                            var f2 = Console.ReadLine();

                            if (int.TryParse(k1, out var k1Val)
                                && int.TryParse(k2, out var k2Val)
                                && float.TryParse(f1, out var f1Val)
                                && float.TryParse(f2, out var f2Val))
                            {
                                var response = _connection.Sum(
                                    new A { S = s1, K = k1Val, F = f1Val },
                                    new A { S = s2, K = k2Val, F = f2Val });

                                Console.WriteLine($"A = [S = {response.S}, K = {response.K}, F = {response.F}]");
                            }
                            else
                            {
                                Console.WriteLine("Check inputs");
                            }

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid code");
                            break;
                        }
                }
            }
        }
    }
}
