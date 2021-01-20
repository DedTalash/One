using One.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One.Core
{
    public interface IWeatherMapClient
    {
        Task<WeatherDto> GetWeather(decimal lat, decimal lon); 
    }
}
