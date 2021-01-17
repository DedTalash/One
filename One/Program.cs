using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;
using System.Data;

namespace One
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            TestConnection();
            InsertRecord();
            Console.ReadKey();
          
        }

       private static void InsertRecord()
        {
            using (NpgsqlConnection con = GetConnection())
           {
               string query = @"insert into public.coord(Lon,Lat)values(20,30)";
               NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if(n==1)
                {
                    Console.WriteLine("Added");
                }
            }
        }
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
        
        private static void TestConnection()
        {
          
            using (NpgsqlConnection con=GetConnection())
           {
               con.Open();
                if (con.State==ConnectionState.Open)
                {
                    Console.WriteLine("Connected");
                }
            }
       }
        
        
      private static NpgsqlConnection GetConnection()
       {
         return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=zayash;Database=One");
       }
    }
}
