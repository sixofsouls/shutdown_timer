using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShutdownTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************");
            Console.WriteLine("   RIGHT NOW ITS \n\n" + DateTime.Now);
            Console.WriteLine("*******************\n\n  Shutdown PC in ");

            int hoursToWait, minutesToWait;

            inputhours:
            Console.Write("Hours = ");
            var hoursToWaitParse = Console.ReadLine();
            if (!int.TryParse(hoursToWaitParse, out hoursToWait))
            {
                Console.WriteLine("Input is incorrect\n\n");
                goto inputhours;
            }

            inputminutes:
            Console.Write("Minutes = ");
            var minutesToWaitParse = Console.ReadLine();
            if (!int.TryParse(minutesToWaitParse, out minutesToWait))
            {
                Console.WriteLine("Input is incorrect\n\n");
                goto inputminutes;
            }

            var startTime = DateTime.Now.Minute;
            int timeToWait = minutesToWait + (hoursToWait * 60);
            int shutdownTime = startTime + timeToWait;

            Stopwatch s = new Stopwatch();
            s.Start();
            while (s.Elapsed < TimeSpan.FromMinutes(timeToWait))
            {
                var timeLeft = shutdownTime - (startTime++);
                Console.WriteLine("Shutting down in " + timeLeft + " minutes");
                Thread.Sleep(60000);
            }
            s.Stop();
            Console.WriteLine("Shutting down...");
            Thread.Sleep(5000);
            Process.Start("shutdown", "/s /t 0");
        }
    }
}
