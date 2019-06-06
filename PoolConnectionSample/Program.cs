using System;
using System.Data.SqlClient;
using System.Data;

namespace PoolConnectionSample
{
    class Program
    {
        private static ContextDAO context = new ContextDAO();
        private static SqlCommand command = new SqlCommand();
        private static SqlDataReader reader;

        static void Main(string[] args)
        {

            /*
            string sqlConnection = "Server= localhots; User Id=elles; Password=54321;" +
                "Integrated security = SSPI; Database = PlantAndHealth";
            */

            /*connection.ConnectionString = sqlConnection + "Connection Timeout = 30;" +
                "Connection Lifetime = 0; Min Pool Size = 0; Max Pool Size = 100; Pooling = true";
            */
            

            try
            {

                Console.WriteLine("==================== Connection 1 =========================");

                command.CommandText = "SELECT TOP 100 * FROM ARTICULOS";
                command.CommandType = CommandType.Text;
                command.Connection = context.sConNme;

                context.openSqlConn(context.sConNme);

                using (reader = command.ExecuteReader())
                {
                    Console.WriteLine("Codigo Producto\tNombre\t\tFamilia\t\tPrecio Unitario\t\tCosto Unitario");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2} \t | {3} \t | {4}",
                        reader[0], reader[1], reader[2], reader[3], reader[4]));
                    }
               
                }

                reader.Close();
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
                reader.Close();
            }


            try
            {
                Console.WriteLine("==================== Connection 2 =========================");

                command.CommandText = "SELECT * FROM REGION";
                command.CommandType = CommandType.Text;
                command.Connection = context.sConNme;

                context.openSqlConn(context.sConNme);

                using (reader = command.ExecuteReader())
                {
                    Console.WriteLine("REGION ID\t\tREGION");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1}",
                        reader[0], reader[1]));
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
                reader.Close();
            }

            try
            {
                Console.WriteLine("==================== Connection 3 =========================");

                command.CommandText = "SELECT * FROM COMUNA;";
                command.CommandType = CommandType.Text;
                command.Connection = context.sConNme;

                context.openSqlConn(context.sConNme);

                using (reader = command.ExecuteReader())
                {
                    Console.WriteLine("COMUNA ID\t\tCOMUNA NOMBRE\t\tPROVINCIA ID");
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0} \t | {1} \t | {2}",
                        reader[0], reader[1], reader[2]));
                    }
                }

                reader.Close();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
                reader.Close();
            }
        }
    }
}
