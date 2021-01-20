using System;
using System.Collections.Generic;
using System.Text;

namespace One.Core.DTO
{
    public class WeatherDto
    {
        public DateTime Date { get; set; }
        public int Pressure { get; set; }
        public double FeelLike { get; set; }
        public int Humidity { get; set; }
        public double Temp { get; set; }
    }
}
