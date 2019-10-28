using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmHelpers;

using Xamarin.Forms;

using Tripero.Models;
using Tripero.Views;

namespace Tripero.ViewModels
{
    public class TripsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Trip> Trips { get; set; }
        public Command LoadTripsCommand { get; set; }

        public TripsViewModel()
        {
            Title = "Browse";
            Trips = new ObservableRangeCollection<Trip>();
            LoadTripsCommand = new Command(async () => await ExecuteLoadTripsCommand());

            MessagingCenter.Subscribe<NewTripPage, Trip>(this, "AddItem", async (obj, trip) =>
            {
                var newTrip = trip as Trip;
                Trips.Add(newTrip);
                await DataStore.AddTripAsync(newTrip);
            });
        }

        async Task ExecuteLoadTripsCommand()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Trips.Clear();
                var trips = await DataStore.GetTripsAsync(true);
                Trips.ReplaceRange(trips);
                Title = $"Trips ({Trips.Count})";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}