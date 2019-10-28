using System;
using System.Collections.Generic;
using System.Text;

namespace Tripero.Models
{
    public class Trip
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
}
}
