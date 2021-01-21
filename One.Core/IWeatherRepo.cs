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
        
        int? IsId(decimal lat, decimal lon);
        WeatherDto GetWeatherFromDB(int id);
        int InsertCoord(decimal lat, decimal lon);
        void InsertWeather(int id, WeatherDto currentWeather);
        List<CoordDto> GetAllCoord();


    }
}