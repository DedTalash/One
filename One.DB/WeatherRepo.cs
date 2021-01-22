using One.Core;
using One.Core.DTO;
using One.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.DB
{
    public class WeatherRepo : IWeatherRepo
    {
        public string IsId(decimal lat, decimal lon)
        {
            using var db = new OneContext();
            //var res = db.Coords.Where(elem => elem.Lat == lat && elem.Lon == lon).Select(elem => elem.Id);
            //bool result = db.Users.Any(elem => elem.Lat == lat && elem.Lon == lon);
            var res = db.Coords.FirstOrDefault(elem => elem.Lat == lat && elem.Lon == lon)?.Id;
            return res;

        }
        public WeatherDto GetWeatherFromDB(string id)
        {
            using var db = new OneContext();
            {
                DateTime lastDate = db.Weathers.Where(elem => elem.Id == id).Max(elem => elem.Date);
                var key = db.Weathers.FirstOrDefault(elem=> elem.Date==lastDate && elem.Id == id).Key;
                var res = db.Weathers.Find(key);
                return new WeatherDto
                {
                    Date = res.Date,
                    FeelLike = res.FeelLike,
                    Humidity = res.Humidity,
                    Pressure = res.Pressure,
                    Temp = res.Temp
                };
            }
        }

        public string InsertCoord(decimal lat, decimal lon)
        {
            using (var db = new OneContext())
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
            using (var db = new OneContext())
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
            return GetWeatherFromDB(IsId(lat, lon));
        }

        public List<CoordDto> GetAllCoord()
        {
            using var db = new OneContext();
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


