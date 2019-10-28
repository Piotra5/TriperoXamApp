using System;
using System.Threading.Tasks;
using Tripero.Models;
using Xamarin.Forms;

namespace Tripero.ViewModels
{
    public class TripDetailViewModel : BaseViewModel
    {
        public Trip Trip { get; set; }
        public TripDetailViewModel(Trip trip = null)
        {
            Title = trip?.Text;
            Trip = trip;
        }

    }
}
