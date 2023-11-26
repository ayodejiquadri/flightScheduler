using FlightScheduler.Contracts;
using FlightScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightScheduler
{
    /// <summary>
    /// The application class for the management system
    /// </summary>
    public class InventoryManagementApplication
    {
        private readonly IInventoryManagerService _inventoryManagerService;

        public InventoryManagementApplication(IInventoryManagerService inventoryManagerService)
        {
            _inventoryManagerService = inventoryManagerService;
        }

        /// <summary>
        /// Runs the application
        /// </summary>
        /// <returns>A <see cref="Task"/></returns>

        public async Task Run()
        {
            while (true)
            {
                Console.WriteLine("Press '1' to View flight Schedule.");
                Console.WriteLine("Press '2' to Assign orders to flights");
                Console.WriteLine("Press 'x' to Exit");
                char key = Console.ReadKey().KeyChar;
                if (key == '1')
                {
                    var flights = await _inventoryManagerService.GetFlightSchedule();
                    DisplayFlights(flights);
                }
                else if (key == '2')
                {
                    var orderSchedule = await _inventoryManagerService.GetOrderSchedule();
                    DisplayScheduledOrders(orderSchedule);
                }
                else if (key == 'x')
                {
                    Console.WriteLine("Application Exited");
                    break;
                }
                else
                {
                    Console.WriteLine($"Wrong Input. {Environment.NewLine}");
                }
            }
        }

        private void DisplayScheduledOrders(ICollection<Order> orders)
        {
            Console.WriteLine();
            var builder = new StringBuilder();
            var count = 0;

            var scheduledOrders = orders.Where(order => order.Flight != null);
            var unscheduledOrders = orders.Where(order => order.Flight == null);

            Console.WriteLine($"**Scheduled Orders**{Environment.NewLine}");

            foreach (var order in scheduledOrders)
            {
                builder.AppendLine($"{++count}. Order: {order.OrderNumber}, FlightNumber: {order.Flight.FlightNumber}, Departure: {order.Flight.Departure}, Arrival: {order.Destination}, Day: {order.Flight.Day}");
            }

            Console.WriteLine(builder.ToString());

            builder.Clear();
            count = 0;

            Console.WriteLine($"**Unscheduled Orders**{Environment.NewLine}");

            foreach (var order in unscheduledOrders)
            {
                builder.AppendLine($"{++count}. Order: {order.OrderNumber}, Destination: {order.Destination}, FlightNumber: Not Scheduled");
            }

            Console.WriteLine(builder.ToString());
        }

        private void DisplayFlights(ICollection<Flight> flights)
        {
            Console.WriteLine();
            var builder = new StringBuilder();
            var count = 0;

            foreach (var flight in flights)
            {
                builder.AppendLine($"{++count}. Flight: {flight.FlightNumber}, Departure: {flight.Departure}, Arrival:{flight.Destination}, Day: {flight.Day}");
            }

            Console.WriteLine(builder.ToString());
        }
    }
}