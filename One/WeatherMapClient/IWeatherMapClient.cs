using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One.WeatherMapClient
{
    public interface IWeatherMapClient
    {
        Task<decimal> GetWeather(string location); 
    }

    public class WeatherMapClientImpl : IWeatherMapClient
    {
        public  Task<decimal> GetWeather(string location)
        {
            return  Task.FromResult(10m);
        }
    }
}
