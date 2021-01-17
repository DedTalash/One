using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One.DbSchema
{
    public partial  class Clouds
    {
        public int all { get; set; }
        public ICollection<CurrentWeatherEntity> currentWeatherEntities  { get; set; }
    }
}
