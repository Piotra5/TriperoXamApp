using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripero.Models;

namespace Tripero.Services
{
    class TripDataStore : IDataStore<Trip>
    {

        readonly List<Trip> trips;

        public TripDataStore()
        {
            trips = new List<Trip>()
        {
            new Trip { Id = Guid.NewGuid().ToString(), Text = "Oldschool trip", Description="" },
            new Trip { Id = Guid.NewGuid().ToString(), Text = "Second trip", Description="This is an trip description." },
            new Trip { Id = Guid.NewGuid().ToString(), Text = "Third trip", Description="This is an trip description." },
            new Trip { Id = Guid.NewGuid().ToString(), Text = "Fourth trip", Description="This is an trip description." },
            new Trip { Id = Guid.NewGuid().ToString(), Text = "Fifth trip", Description="This is an trip description." },
            new Trip { Id = Guid.NewGuid().ToString(), Text = "Sixth trip", Description="This is an Trip description." }
        };
        }

        public async Task<bool> AddTripAsync(Trip Trip)
        {
            trips.Add(Trip);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateTripAsync(Trip Trip)
        {
            var oldTrip = trips.Where((Trip arg) => arg.Id == Trip.Id).FirstOrDefault();
            trips.Remove(oldTrip);
            trips.Add(Trip);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteTripAsync(string id)
        {
            var oldTrip = trips.Where((Trip arg) => arg.Id == id).FirstOrDefault();
            trips.Remove(oldTrip);

            return await Task.FromResult(true);
        }

        public async Task<Trip> GetTripAsync(string id)
        {
            return await Task.FromResult(trips.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Trip>> GetTripsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(trips);
        }
    }
}