using One.Core;
using One.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One.Core

{
    public class WeatherService
    {
        private readonly IWeatherMapClient weatherMapClient;
        private readonly IWeatherRepo weatherRepo;

        public WeatherService(IWeatherMapClient weatherMapClient, IWeatherRepo weatherRepo)
        {
            this.weatherMapClient = weatherMapClient;
            this.weatherRepo = weatherRepo;
        }

        public async Task<WeatherDto> GetWeather(decimal lat, decimal lon) 
        {
          var ID = weatherRepo.IsId(lat, lon);
            if (ID != null)
            {
                return weatherRepo.GetWeatherFromDB(ID);
            }
            var currentWebWeather = await weatherMapClient.GetWeather(lat,lon);
            string newId = weatherRepo.InsertCoord(lat, lon);
            weatherRepo.InsertWeather(newId,currentWebWeather );
            return currentWebWeather;
        }

        public async Task UpdateBD()
        {
           List<CoordDto> list = weatherRepo.GetAllCoord();
            foreach (CoordDto l in list)
            {
                var currentWebWeather = await weatherMapClient.GetWeather(l.Lat, l.Lon);
                weatherRepo.InsertWeather(l.Id, currentWebWeather);
            }
        }
    }
}
