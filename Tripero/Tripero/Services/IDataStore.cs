using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tripero.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddTripAsync(T trip);
        Task<bool> UpdateTripAsync(T item);
        Task<bool> DeleteTripAsync(string id);
        Task<T> GetTripAsync(string id);
        Task<IEnumerable<T>> GetTripsAsync(bool forceRefresh = false);
    }
}
