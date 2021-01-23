using One.Core;
using One.Core.DTO;
using One.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace One.DB
{
    // TODO: Make all methods async
    public class WeatherRepo : IWeatherRepo
    {
        private readonly string _connectionString;

        public WeatherRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public string IsId(decimal lat, decimal lon)
        {
            var context = new DbContextOptions<OneContext>();
            using var db = new OneContext(_connectionString);
            //var res = db.Coords.Where(elem => elem.Lat == lat && elem.Lon == lon).Select(elem => elem.Id);
            //bool result = db.Users.Any(elem => elem.Lat == lat && elem.Lon == lon);
            var res = db.Coords.FirstOrDefault(elem => elem.Lat == lat && elem.Lon == lon)?.Id;
            return res;

        }
        public async Task<WeatherDto> GetWeatherFromDB(string id)
        {
            using var db = new OneContext(_connectionString);
            DateTime lastDate = db.Weathers.Where(elem => elem.Id == id).Max(elem => elem.Date);
            var key = await db.Weathers.FirstOrDefaultAsync(elem=> elem.Date==lastDate && elem.Id == id);
            if (key == null) 
                return null;
            var res = await db.Weathers.FindAsync(key.Key);
            return new WeatherDto
            {
                Date = res.Date,
                FeelLike = res.FeelLike,
                Humidity = res.Humidity,
                Pressure = res.Pressure,
                Temp = res.Temp
            };
        }

        public string InsertCoord(decimal lat, decimal lon)
        {
            using (var db = new OneContext(_connectionString))
            {
                db.Add(new Coord
                {
                    Id = Guid.NewGuid().ToString(),
                    Lat = lat,
                    Lon = lon
                });
                db.SaveChanges();
                var res = db.Coords.FirstOrDefault(elem => elem.Lat == lat && elem.Lon == lon)?.Id;
                return res;
            }
        }

        public void InsertWeather(string id, WeatherDto currentWeather)
        {
            using (var db = new OneContext(_connectionString))
            {
                db.Add(new Weather
                {
                    Key = Guid.NewGuid().ToString(),
                    Date = currentWeather.Date,
                    FeelLike = currentWeather.FeelLike,
                    Id = id,
                    Humidity = currentWeather.Humidity,
                    Pressure = currentWeather.Pressure,
                    Temp = currentWeather.Temp
                });
                db.SaveChanges();
            }
        }


        public WeatherDto GetCurrentWeather(decimal lat, decimal lon)
        {
            return GetWeatherFromDB(IsId(lat, lon)).GetAwaiter().GetResult();
        }

        public List<CoordDto> GetAllCoord()
        {
            using var db = new OneContext(_connectionString);
            var list = db.Coords.ToList();
            List<CoordDto> res = new List<CoordDto>();
            foreach (var l in list)
            {
                res.Add( 
                new CoordDto
                {
                    Id = l.Id,
                    Lat = l.Lat,
                    Lon = l.Lon
                });
            }
            return res;
        }
    }
}


