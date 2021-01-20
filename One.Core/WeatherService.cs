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

        public async Task<WeatherDto> GetWeather(decimal lat, decimal lon) 
        {
          var ID = weatherRepo.IsId(lat, lon);
            if (ID != 0)
            {
                return weatherRepo.GetWeatherFromDB((int)ID);
            }
            var currentWebWeather = await weatherMapClient.GetWeather(lat,lon);
            weatherRepo.InsertCoord(lat, lon);
            int newId = (int)weatherRepo.IsId(lat, lon);
            weatherRepo.InsertWeather(newId,currentWebWeather );

            return currentWebWeather;

        }
    }
}
