using lab_7_feed;
using System;
using System.ServiceModel.Web;

namespace Lab7.Host
{
    class Program
    {
        static void Main()
        {
            using (WebServiceHost host = new WebServiceHost(typeof(Feed1)))
            {
                host.Open();
                Console.WriteLine($"Student Notes Feed Started: {DateTime.Now}");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
