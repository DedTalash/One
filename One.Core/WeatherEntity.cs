using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One.Core
{

    public class WeatherEntity
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public int Pressure { get; set; }
        public double FeelLike { get; set; }
        public int Humidity { get; set; }
        public double Temp { get; set; }
    }
}
