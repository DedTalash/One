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

namespace One.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherMapClient _weatherMapClient;
        private readonly HttpClient _httpClient;
        private readonly string _key = "c5ecf5f5261efc0bfed1e6552cd5c6ca";
       


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, HttpClient httpClient, IWeatherMapClient weatherMapClient)
        {
            _logger = logger;
            _weatherMapClient = weatherMapClient;
            _httpClient = httpClient;
        }



        

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync(double lat, double lon)
        {
            //string key = "c5ecf5f5261efc0bfed1e6552cd5c6ca";

            var responseString = await _httpClient.GetStringAsync($"api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={_key}");

            var weather = JsonConvert.DeserializeObject<WeatherForecast>(responseString);
           

            //var jobId = BackgroundJob.Schedule(
            //    () => _logger.LogInformation($"Weather client: {_weatherMapClient.GetWeather("")}"),
            //    TimeSpan.FromSeconds(1));
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                Lat = rng.Next(0, 90),
                Lon = rng.Next(0, 90),

            })
            .ToArray();
        }
    }
}
