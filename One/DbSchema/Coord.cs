using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One.DbSchema
{
    public partial class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }

        public ICollection<CurrentWeatherEntity> currentWeatherEntities { get; set; }
    }
}
