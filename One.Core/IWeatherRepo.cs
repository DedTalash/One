using One.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace One.Core
{
    public interface IWeatherRepo
    {
        WeatherDto GetCurrentWeather(decimal lat, decimal lon);
        
        string IsId(decimal lat, decimal lon);
        WeatherDto GetWeatherFromDB(string id);
        string InsertCoord(decimal lat, decimal lon);
        void InsertWeather(string id, WeatherDto currentWeather);
        List<CoordDto> GetAllCoord();


    }
}