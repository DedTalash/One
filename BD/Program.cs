using System;
using System.Data;
using Npgsql;

namespace BD
{
    class Program
    {
        static void Main(string[] args)
        {
           // TestConnection();
            Insert();
            Console.ReadKey();
        }

        private static void Insert()
        {
            using (NpgsqlConnection connection = GetConnection())
            {
                string query = @"insert into public.coord(Lon,Lat)values(130,120)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                connection.Open();
                int n = cmd.ExecuteNonQuery();
                if(n==1)
                {
                    Console.WriteLine("ADD");
                }
            }
        }
        private static void TestConnection()
        {
            using (NpgsqlConnection connection = GetConnection())
            {
                connection.Open();
                if(connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connect");
                }
            }
        }
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Database=One;Password=zayash;");
        }
    }
}
