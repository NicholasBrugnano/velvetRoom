using System.Reflection;

namespace MultiThreadEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"i am tenna! Inside method: {MethodBase.GetCurrentMethod().Name}");
            //DoWork();
            //DoWorkWithParameter(9);
            UseThreads();
            Console.WriteLine("i hate spamton!");
        }

        private static void DoWork()
        {
            Console.WriteLine($"Inside method: {MethodBase.GetCurrentMethod().Name}");

            Console.WriteLine($"Managed thread ID: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(2000);

            Console.WriteLine("Doing work in DoWork()...");
        }

        private static void DoWorkWithParameter(object param)
        {
            Console.WriteLine($"Inside method: {MethodBase.GetCurrentMethod().Name}");

            Console.WriteLine($"Managed thread ID: {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"Result {Convert.ToInt32(param) * Convert.ToInt32(param)}");
        }

        private static void Scream(object screams)
        {
            int screamer = Convert.ToInt32(screams);
            for (int i = 0; i < screamer; i++)
            {
                Console.WriteLine("AAAAAAAAAA");
                Thread.Sleep(250);
            }
        }

        private static void UseThreads()
        {
            Console.WriteLine($"Inside method: {MethodBase.GetCurrentMethod().Name}");

            var thread = new Thread( DoWork );
            Console.WriteLine($"Thread state BEFORE start: {thread.ThreadState}");

            thread.Start();
            Console.WriteLine($"Thread state AFTER start: {thread.ThreadState}");

            var paramThread = new Thread( DoWorkWithParameter );
            Console.WriteLine($"Param thread state BEFORE start: {paramThread.ThreadState}");

            paramThread.Start(5);
            Console.WriteLine($"Param thread state AFTER start: {paramThread.ThreadState}");

            var screamThread = new Thread(DoWork);
            Console.WriteLine($"Scream Thread state BEFORE start: {screamThread.ThreadState}");

            screamThread.Start(20);
            Console.WriteLine($"Scream Thread state AFTER start: {screamThread.ThreadState}");
        }
    }
}
