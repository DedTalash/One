using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace One.WeatherMapClient
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Coord    {
        public double lon { get; set; } 
        public double lat { get; set; } 
    }

    public class Weather    {
        public int id { get; set; } 
        public string main { get; set; } 
        public string description { get; set; } 
        public string icon { get; set; } 
    }

    public class Main    {
        public double temp { get; set; } 
        public double feels_like { get; set; } 
        public double temp_min { get; set; } 
        public double temp_max { get; set; } 
        public int pressure { get; set; } 
        public int humidity { get; set; } 
    }

    public class Wind    {
        public double speed { get; set; } 
        public int deg { get; set; } 
    }

    public class Clouds    {
        public int all { get; set; } 
    }

    public class Sys    {
        public int type { get; set; } 
        public int id { get; set; } 
        public double message { get; set; } 
        public string country { get; set; } 
        public int sunrise { get; set; } 
        public int sunset { get; set; } 
    }

    public class CurrentWeather    {
        public Coord coord { get; set; } 
        public IEnumerable<Weather> weather { get; set; } 
        public string @base { get; set; } 
        public Main main { get; set; } 
        public int visibility { get; set; } 
        public Wind wind { get; set; } 
        public Clouds clouds { get; set; } 
        public int dt { get; set; } 
        public Sys sys { get; set; } 
        public int timezone { get; set; } 
        public int id { get; set; } 
        public string name { get; set; } 
        public int cod { get; set; } 
    }

    public class WeatherMapClientImpl : IWeatherMapClient
    {
        private const string Key = "c5ecf5f5261efc0bfed1e6552cd5c6ca";
        
        private readonly HttpClient _httpClient;

        public WeatherMapClientImpl(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrentWeather> GetWeather(double lat, double lon)
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid={Key}";
            var result = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<CurrentWeather>(result);
        }
    }
}