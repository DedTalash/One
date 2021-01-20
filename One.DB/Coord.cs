using System;
using System.Collections.Generic;

#nullable disable

namespace One.DB
{
    public partial class Coord
    {
        public int Id { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lon { get; set; }
    }
}
