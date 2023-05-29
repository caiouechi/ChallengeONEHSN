﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchApi.Models
{
    public class Coordinate
    {
        public int? X { get; set; }
        public int? Y { get; set; }
        public Coordinate(int? x, int? y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}