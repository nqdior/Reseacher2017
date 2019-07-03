using System;

namespace newtype.Common
{
    public static class TimeCounter
    {
        private static DateTime startDt;

        private static DateTime endDt;

        public static void Start()
        {
            Console.WriteLine("start");
            startDt = DateTime.Now;

            System.Threading.Thread.Sleep(1000);
        }

        public static void End()
        {
            endDt = DateTime.Now;
            TimeSpan ts = endDt - startDt; 

            Console.WriteLine("time - minutes : " + ts.TotalMinutes); 
            Console.WriteLine("time - second : " + ts.TotalSeconds); 
            Console.WriteLine("time - m second : " + ts.TotalMilliseconds); 

            Console.ReadKey();
        }
    }
}
