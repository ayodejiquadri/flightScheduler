using FlightScheduler.Contracts;
using FlightScheduler.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightScheduler.Services
{
    /// <summary>
    /// The implementation of the <see cref="IInventoryManagerService"/>
    /// </summary>
    public class InventoryManagerService : IInventoryManagerService
    {
        private readonly IFlightService _flightService;
        private readonly IOrderService _orderService;

        /// <summary>
        /// Initializes an instance of the <see cref="InventoryManagerService"/>
        /// </summary>
        /// <param name="flightService"><see cref="IFlightService"/> instance</param>
        /// <param name="orderService"><see cref="IOrderService"/> instance</param>
        public InventoryManagerService(IFlightService flightService, IOrderService orderService)
        {
            _flightService = flightService;
            _orderService = orderService;
        }

        /// <inheritdoc cref="IInventoryManagerService.GetFlightSchedule"/>
        public Task<ICollection<Flight>> GetFlightSchedule()
        {
            var flights = _flightService.GetFlights();
            return flights;
        }

        /// <inheritdoc cref="IInventoryManagerService.GetOrderSchedule"/>
        public async Task<ICollection<Order>> GetOrderSchedule()
        {
            IDictionary<string, Order> ordersDictionary = await _orderService.GetOrders(); // the key is the orderId
            var orders = ordersDictionary.Values;
            var flights = await _flightService.GetFlights();

            if (orders.Count == 0 || flights.Count == 0)
            {
                return orders;
            }

            Dictionary<string, Queue<Order>> destinationOrdersMapping = GroupOrdersByDestination(orders); // the key is the destination.

            foreach (var flight in flights)
            {
                var isOrderAvailableForDestination = destinationOrdersMapping.ContainsKey(flight.Destination)
                    && destinationOrdersMapping[flight.Destination].Count > 0;

                if (isOrderAvailableForDestination)
                {
                    AssignOrdersToFlight(flight, destinationOrdersMapping[flight.Destination]); // O(1) operation for getting the orders for a particular destination
                }
            }

            return orders;
        }

        
        private void AssignOrdersToFlight(Flight flight, Queue<Order> ordersForDestination)
        {
            while (flight.Orders.Count < flight.MaxCapacity && ordersForDestination.Count > 0)
            {
                var order = ordersForDestination.Dequeue(); // O(1) operation for assigning order to a flight.
                order.Flight = flight;
                flight.Orders.Add(order);
            }
        }

        private Dictionary<string, Queue<Order>> GroupOrdersByDestination(ICollection<Order> orders)
        {
            var destinationOrdersMapping = new Dictionary<string, Queue<Order>>();
            var rankedOrders = orders.OrderBy(order => order.Priority);

            foreach (var order in rankedOrders)
            {
                if (destinationOrdersMapping.ContainsKey(order.Destination))
                {
                    destinationOrdersMapping[order.Destination].Enqueue(order);
                }
                else
                {
                    destinationOrdersMapping.Add(order.Destination, new Queue<Order>());
                    destinationOrdersMapping[order.Destination].Enqueue(order);
                }
            }

            return destinationOrdersMapping;
        }
    }
}