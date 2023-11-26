using FlightScheduler.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightScheduler.Contracts
{
    /// <summary>
    /// Defines the contract for an Inventory Manager service.
    /// </summary>
    public interface IInventoryManagerService
    {
        /// <summary>
        /// Retrieves the flight schedule
        /// </summary>
        /// <returns> <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains a <see cref="ICollection{T}"/> that contains the available flights</returns>
        Task<ICollection<Flight>> GetFlightSchedule();

        /// <summary>
        /// Retrieves the order scheudle
        /// </summary>
        /// <returns><see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains a <see cref="ICollection{T}"/> that contains the order schedule</returns>
        Task<ICollection<Order>> GetOrderSchedule();
    }
}