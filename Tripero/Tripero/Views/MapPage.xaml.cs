using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tripero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public List<string> AddressPointList { get; set; }

        public MapPage()
        {
            BindingContext = this;

            AddressPointList = new List<string>()
            {
                "72230 Ruaudin, France",
                "72100 Le Mans, France",
                "77500 Chelles, France"
            };

            InitializeComponent();
        }
    }
}