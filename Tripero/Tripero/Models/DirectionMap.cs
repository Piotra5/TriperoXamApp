using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Tripero.Models
{
    public class DirectionMap
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public Address address_start { get; set; }
        public Address address_end { get; set; }
        public List<Step> steps { get; set; }

        public class Distance
        {
            public string text { get; set; }
            public int value { get; set; }
        }
        public class Duration
        {
            public string text { get; set; }
            public int value { get; set; }
        }
        public class Address
        {
            public string text { get; set; }
            public Position position { get; set; }
        }
        public class Step
        {
            public Position start { get; set; }
            public Position end { get; set; }
        }
    }
}
