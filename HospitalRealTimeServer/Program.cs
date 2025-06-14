using Microsoft.Owin.Hosting;
using System;

namespace HospitalRealTimeServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080";
            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("✅ SignalR Server running at " + url);
                Console.WriteLine("🔄 Press ENTER to stop the server...");
                Console.ReadLine(); // Keeps the console app alive until you press Enter
            }
        }
    }
}
