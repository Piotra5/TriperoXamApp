//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Tripero.Models;
//using Xamarin.Forms;
//using Xamarin.Forms.Maps;
//using Xamarin.Forms.Xaml;

//namespace Tripero.Views
//{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
//    public partial class MapPagev01 : ContentPage
//    {
//        public MapPagev01()
//        {
//            int i = 0;
//            //InitializeComponent();
//            var pin = new CustomPin
//            {
//                Type = PinType.Place,
//                Position = new Position(49.6886600, 21.7705800),
//                Label = "Start Trasy",
//                Address = "Krosno",
//                MarkerId = "KR",
//                Url = "https://krosno.pl"
//            };

//            var map = new CustomMap
//            {
//                CustomPins = new List<CustomPin> { pin },
//                IsShowingUser = false,
//                HasZoomEnabled = true,
//                HeightRequest = 100,
//                WidthRequest = 960,
//                VerticalOptions = LayoutOptions.FillAndExpand
//            };
//            map.Pins.Add(pin);
//            map.MoveToRegion(MapSpan.FromCenterAndRadius(
//              new Position(49.6886600, 21.7705800), Distance.FromKilometers(0.01)));

//            var stack = new StackLayout { Spacing = 0 };
//            stack.Children.Add(map);
//            Content = stack;
//        }
//    }
//}