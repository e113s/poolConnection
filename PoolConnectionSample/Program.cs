using System;
using System.Data.SqlClient;
using System.Data;

namespace PoolConnectionSample
{
    class Program
    {
        private static ContextDAO context;
        private static ContextDAO context2;
        private static SqlConnection connection1;
        private static SqlConnection connection2;
        private static SqlConnection connection3;
        private static DateTime time;
        private static DateTime startTime;
        private static DateTime endTime;
        private static TimeSpan startTimeSpan;
        private static TimeSpan endTimeSpan;

        private static bool isBetween(DateTime time, DateTime startTime, DateTime endTime)
        {
            if (time.TimeOfDay == startTime.TimeOfDay) return true;
            if (time.TimeOfDay == endTime.TimeOfDay) return true;

            if (startTime.TimeOfDay <= endTime.TimeOfDay)
                return (time.TimeOfDay >= startTime.TimeOfDay && time.TimeOfDay <= endTime.TimeOfDay);
            else
                return !(time.TimeOfDay >= endTime.TimeOfDay && time.TimeOfDay <= startTime.TimeOfDay);

        }

        static void Main(string[] args)
        {
            time = DateTime.Now;
            startTime = Convert.ToDateTime("16:00:00 PM");
            endTime = Convert.ToDateTime("19:00:00 PM");
            Console.WriteLine(time);
            Console.WriteLine(startTime);
            Console.WriteLine(endTime);

            Console.WriteLine(isBetween(time, startTime, endTime));

            if (isBetween(time, startTime, endTime))
            {
                //Pruebas conexion
                context = new ContextDAO();
                connection1 = context.sConNme;
                connection2 = context.sConNme;

                connection1.Open();
                //connection2.Open();
                Console.WriteLine("State of connection 1: " + connection1.State);
                Console.WriteLine("State of connection 2: " + connection2.State);
                //Console.WriteLine("State of connection 3: " + connection3.State);

                Console.WriteLine("================================================================");
                connection1.Dispose();
                //connection2.Dispose();
                Console.WriteLine("State of connection 1: " + connection1.State);
                Console.WriteLine("State of connection 2: " + connection2.State);
                //Console.WriteLine("State of connection 3: " + connection3.State);
                Console.Read();

            }
            else
            {
                Console.Write("No tienes permiso para acceder en estos momentos shavo :c");
            }



            Console.Read();
        }
    }
}
