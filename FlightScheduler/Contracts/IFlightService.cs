using FlightScheduler.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightScheduler.Contracts
{
    /// <summary>
    /// Defines the contract for a flight service.
    /// </summary>
    public interface IFlightService
    {
        /// <summary>
        /// Gets the available flights
        /// </summary>
        /// <returns> <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains a <see cref="ICollection{T}"/> that contains the available flights.</returns>
        Task<ICollection<Flight>> GetFlights();
    }
}