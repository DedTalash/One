﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One.DbSchema
{
    public partial class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }
}
