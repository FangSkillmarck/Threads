using System;
using System.Timers;
using System.Threading;
using System.Diagnostics;


namespace Threads
{
    class Program
    {

        private static System.Timers.Timer aTimer;
        public static void Main(string[] args)
        {
            Console.WriteLine("Press the Enter key to exit the program at any time... ");

            SetTimer();

            Console.ReadKey();

            Console.WriteLine("Terminating the application in one second...");

            aTimer.Stop();
            aTimer.Dispose();

            Thread.Sleep(1000);

            Console.WriteLine("Main Thread Quits..!");
            Console.WriteLine("The application is terminated...");
        }

        static void WorkThread1()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thread1");
            Thread.Sleep(100);
        }
        static void WorkThread2()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Thread2");
            Thread.Sleep(200);
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Thread oThread1 = new Thread(WorkThread1);
            Thread oThread2 = new Thread(WorkThread2);
            oThread1.Start();
            oThread2.Start();
            oThread1.Abort();
            oThread2.Abort();
        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer();

            aTimer.Elapsed += OnTimedEvent;
            
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
    }
}
