using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using One.WeatherMapClient;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Http;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using One.Core;
using One.Core.DTO;

namespace One.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherMapClient _weatherMapClient;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherMapClient weatherMapClient)
        {
            _logger = logger;
            _weatherMapClient = weatherMapClient;
        }

        // public WeatherForecast GetWeatherFtomSite(double lat, double lon)
        // {
        //     var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //     var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //     using var streamReader = new StreamReader(httpWebResponse.GetResponseStream());
        //     var answer = streamReader.ReadToEnd();
        //     var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(answer);
        //     return weatherForecast;
        // }



        [HttpGet("{lat}/{lon}")]
        public async Task<WeatherDto> GetAsync(decimal lat, decimal lon)
        {
            //string key = "c5ecf5f5261efc0bfed1e6552cd5c6ca";
            
            //var responseString = await _httpClient.GetStringAsync(http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={_key});

            //var weather = JsonConvert.DeserializeObject<WeatherForecast>(responseString);
           

            //var jobId = BackgroundJob.Schedule(
            //    () => _logger.LogInformation($"Weather client: {_weatherMapClient.GetWeather("")}"),
            //    TimeSpan.FromSeconds(1));
            var weather = await _weatherMapClient.GetWeather(lat, lon);
            return weather;
            
        }
    }
}
