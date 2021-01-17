using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One.WeatherMapClient
{
    public interface IWeatherMapClient
    {
        Task<CurrentWeather> GetWeather(double lat, double lon); 
    }
}
