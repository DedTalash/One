using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace One.DB
{
    public partial class Weather
    {
        public int Key { get; set; }
        public int Id { get; set; }
        public decimal Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public DateTime Date { get; set; }
        public decimal FeelLike { get; set; }
    }
}
