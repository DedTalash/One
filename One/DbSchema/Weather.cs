﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace One.DbSchema
{
    public partial class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
