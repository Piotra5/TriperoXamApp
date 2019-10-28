using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Tripero.Models;
using Tripero.Views;
using Tripero.ViewModels;

namespace Tripero.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TripsPage : ContentPage
    {
        TripsViewModel viewModel;

        public TripsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TripsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var trip = args.SelectedItem as Trip;
            if (trip == null)
                return;

            await Navigation.PushAsync(new TripDetailPage(new TripDetailViewModel(trip)));

            // Manually deselect item.
            TripsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewTripPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Trips.Count == 0)
                viewModel.LoadTripsCommand.Execute(null);
        }
    }
}