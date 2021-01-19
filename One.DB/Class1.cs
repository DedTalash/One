using System;

namespace One.DB
{
    public class DB
    {
        private static Coord IsContain(decimal lat, decimal lon)
        {
            using (var db = new OneContext())
            {
                // var res = db.Coords.Where(elem => elem.Lat == lat && elem.Lon == lon).Select(elem => elem.Id);
                decimal res = db.Coords.FirstOrDefault(elem => elem.Lat == lat && elem.Lon == lon).Select(elem => elem.Id);
                return res;
            }

        }

        private static void Insert(decimal lat, decimal lon, decimal res)
        {
            using (var db = new OneContext())
            {
                db.Add(new Coord
                {
                    Lat = lat,
                    Lon = lon
                });
                db.SaveChanges();
                //var res = db.Coords.Where(elem => elem.Lat == lat && elem.Lon == lon).Select(elem => elem.Id);
                var CurrentWeather currentWeather = GetWeather(lat, lon);
                db.Add(new Weather
                {
                    Date = currentWeather.timezone,
                    Pressure = currentWeather.main.pressure,
                    FeelLike = currentWeather.main.feels_like,
                    Humidity = currentWeather.main.humidity,
                    Id = res,
                    Temp = currentWeather.main.temp
                });
                db.SaveChanges();
            }
        }

        private static Weather[] GetWeatherFromBd(decimal res)
        {
            using (var db = new OneContext())
            {
                return db.Weathers.Where(elem => elem.Id == res).ToArray();
            }

        }

    }
}
