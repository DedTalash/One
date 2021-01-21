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
        private static int staticId = 1;
        private static int staticKey = 1;
        public int? IsId(decimal lat, decimal lon)
        {
            using var db = new OneContext();
            //var res = db.Coords.Where(elem => elem.Lat == lat && elem.Lon == lon).Select(elem => elem.Id);
            //bool result = db.Users.Any(elem => elem.Lat == lat && elem.Lon == lon);
            var res = db.Coords.FirstOrDefault(elem => elem.Lat == lat && elem.Lon == lon)?.Id;
            return res;

        }
        public WeatherDto GetWeatherFromDB(int id)
        {
            using var db = new OneContext();
            {
                int MaxKey = db.Weathers.Where(elem => elem.Id == id).Max(elem => elem.Key);
                var res = db.Weathers.Find(MaxKey);
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

        public int InsertCoord(decimal lat, decimal lon)
        {
            using (var db = new OneContext())
            {
                db.Add(new Coord
                {
                    Id = staticId,
                    Lat = lat,
                    Lon = lon
                });
                db.SaveChanges();
                staticId++;
                var res = db.Coords.FirstOrDefault(elem => elem.Lat == lat && elem.Lon == lon)?.Id;
                return res.Value;
            }
        }

        public void InsertWeather(int id, WeatherDto currentWeather)
        {
            using (var db = new OneContext())
            {
                db.Add(new Weather
                {
                    Key = staticKey,
                    Date = currentWeather.Date,
                    FeelLike = currentWeather.FeelLike,
                    Id = id,
                    Humidity = currentWeather.Humidity,
                    Pressure = currentWeather.Pressure,
                    Temp = currentWeather.Temp
                });
                db.SaveChanges();
                staticKey++;
            }
        }


        public WeatherDto GetCurrentWeather(decimal lat, decimal lon)
        {
            return GetWeatherFromDB(IsId(lat, lon).Value);
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


