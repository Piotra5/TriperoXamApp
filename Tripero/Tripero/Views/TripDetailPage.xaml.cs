using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Tripero.Models;
using Tripero.ViewModels;

namespace Tripero.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TripDetailPage : ContentPage
    {
        TripDetailViewModel viewModel;

        public TripDetailPage(TripDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public TripDetailPage()
        {
            InitializeComponent();

            var trip = new Trip
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new TripDetailViewModel(trip);
            BindingContext = viewModel;
        }

        public async void StartTrip(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new MapPage());
        }

    }
}