using One.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace One.Core
{
    interface IWeatherRepo
    {
        WeatherDto GetCurrentWeather(decimal lat, decimal lon);
        void UpdateData();
        int? IsId(decimal lat, decimal lon);
        WeatherDto GetWeatherFromDB(int id);
        void InsertCoord(decimal lat, decimal lon);
        void InsertWeather(int id, WeatherDto currentWeather);

    }
}