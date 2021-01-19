//using System;
//using System.Data;
//using System.Linq;
//using Npgsql;


//namespace BD
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //// TestConnection();
//            // Insert();
//            // Console.ReadKey();

//               // using (var db = new OneContext())
//               //{
//               //    db.Add(new Coord
//               //     {
//               //       Lat = 16,
//               //       Lon = 15
//               //  }) ;
//               //   db.SaveChanges();

//               //     var res = db.Coords.Where(qw => qw.Id==2).ToList();
//               // }

//           }

//            private static Coord IsContain(decimal lat, decimal lon)
//            {
//                using (var db = new OneContext())
//                {
//                   // var res = db.Coords.Where(elem => elem.Lat == lat && elem.Lon == lon).Select(elem => elem.Id);
//                    var res = db.Coords.FirstOrDefault(elem => elem.Lat == lat && elem.Lon == lon);
//                    return res;
//               }

//            }

//        private static void Insert(decimal lat, decimal lon)
//        {
//            using (var db = new OneContext())
//            {
//                db.Add(new Coord
//                {
//                    Lat=lat,
//                    Lon=lon
//                });
//                db.SaveChanges();
//                var res = db.Coords.Where(elem => elem.Lat == lat && elem.Lon == lon).Select(elem => elem.Id);
//                var  currentWeather = GetWeather(lat,lon);
//                db.Add(new Weather
//                {
//                    Date = currentWeather.timezone,
//                    Pressure = currentWeather.main.pressure,
//                    FeelLike = currentWeather.main.feels_like,
//                    Humidity = currentWeather.main.humidity,
//                    Id=res,
//                    Temp= currentWeather.main.temp
//                }) ;
//                db.SaveChanges();
//            }
//        }

//        private static Weather[] GetWeatherFromBd(int res)
//        {
//            using (var db = new OneContext())
//            {
//                return db.Weathers.Where(elem => elem.Id == res).ToArray();
//            }
            
//        }




//        //    private static void Insert()
//        //    {
//        //        using (NpgsqlConnection connection = GetConnection())
//        //        {
//        //            string query = @"insert into public.coord(Lon,Lat)values(130,120)";
//        //            NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
//        //            connection.Open();
//        //            int n = cmd.ExecuteNonQuery();
//        //            if(n==1)
//        //            {
//        //                Console.WriteLine("ADD");
//        //            }
//        //        }
//        //    }
//        //    private static void TestConnection()
//        //    {
//        //        using (NpgsqlConnection connection = GetConnection())
//        //        {
//        //            connection.Open();
//        //            if(connection.State == ConnectionState.Open)
//        //            {
//        //                Console.WriteLine("Connect");
//        //            }
//        //        }
//        //    }
//        //    private static NpgsqlConnection GetConnection()
//        //    {
//        //        return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Database=One;Password=zayash;");
//        //    }
//    }
//    }

