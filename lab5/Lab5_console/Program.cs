using System;
using System.ServiceModel;

namespace Lab5_console
{
    public class Program
    {
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(Lab5_WCF.WCFSiplex)))
            {
                host.Open();
                Console.WriteLine($"WCFSiplex started: {DateTime.Now}");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
