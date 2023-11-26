using FlightScheduler.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightScheduler.Contracts
{
    /// <summary>
    /// Defines the contract for an order service
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Gets all the orders
        /// </summary>
        /// <returns><see cref="Task{TResult}"/> representing the asynchronous operation.
        /// The task result contains a <see cref="IDictionary{TKey, TValue}"/> 
        /// where the Key is the orderId and the Value is the <see cref="Order"/> itself</returns>
        Task<IDictionary<string, Order>> GetOrders();
    }
}