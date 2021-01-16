using System;

namespace One
{
    public class WeatherForecast
    {
        public double Lat { get; set; }
        public double Lon { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
     }
}
