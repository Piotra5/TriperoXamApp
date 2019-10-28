using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Tripero.Models
{
    public class CustomMapv1 : Map
    {
        public List<CustomPin> CustomPins { get; set; }
    }
}
