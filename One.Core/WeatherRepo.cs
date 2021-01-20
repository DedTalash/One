using One.Core.DTO;
using One.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.Core
{
    public class WeatherRepo : IWeatherRepo
    {
        private readonly IWeatherMapClient weatherMapClient;
        
        public int? IsId(decimal lat, decimal lon)
        {
            using var db = new OneContext();
            // var res = db.Coords.Where(elem => elem.Lat == lat && elem.Lon == lon).Select(elem => elem.Id);
            //bool result = db.Users.Any(elem => elem.Lat == lat && elem.Lon == lon);
            var res = db.Coords.FirstOrDefault(elem => elem.Lat == lat && elem.Lon == lon)?.Id;
            return res;
        }
        public WeatherDto GetWeatherFromDB(int id)
        {
            using var db = new OneContext();
            var res = db.Weathers.Find(id);
            return new WeatherDto
            {
                Date = (DateTime)res.Date,
                FeelLike = (double)res.FeelLike,
                Humidity = (int)res.Humidity,
                Pressure = (int)res.Pressure,
                Temp = (double)res.Temp
            };
        }

        public void InsertCoord(decimal lat, decimal lon)
        {
            using (var db = new OneContext())
            {
                db.Add(new Coord
                {
                    Lat = lat,
                    Lon = lon
                });
                db.SaveChanges();

            }
        }

        public void InsertWeather(int id, WeatherDto currentWeather)
        {
            using (var db = new OneContext())
            {
                db.Add(new Weather
                {
                    Date = currentWeather.Date,
                    FeelLike = (decimal?)currentWeather.FeelLike,
                    Id = id,
                    Humidity = currentWeather.Humidity,
                    Pressure = currentWeather.Pressure,
                    Temp = (decimal?)currentWeather.Temp
                });
                db.SaveChanges();

            }
        }
        public async void UpdateData()
        {
            using (var db = new OneContext())
            {
                var data = db.Coords.ToList();
            //    var data = db.Coords.Join(db.Weathers, u => u.Id, c => c.Id,
            //    (u, c) => new
            //    {
            //        Id = u.Id,
            //        Lat = u.Lat,
            //        Lon = u.Lon,
            //        Date = c.Date,
            //        FeelLike = c.FeelLike,
            //        Humidity = c.Humidity,
            //        Pressure = c.Pressure,
            //        Temp = (decimal?)c.Temp
            //    }
            //);
                foreach (var d in data)
                {
                    WeatherDto weatherDto = await weatherMapClient.GetWeather((decimal)d.Lat, (decimal)d.Lon);
                    InsertWeather(d.Id, weatherDto);
                    db.SaveChanges();
                }

            }
        }

        WeatherDto IWeatherRepo.GetCurrentWeather(decimal lat, decimal lon)
        {
            int ID = (int)IsId(lat, lon);

            return GetWeatherFromDB(ID);
        }
    }
}
