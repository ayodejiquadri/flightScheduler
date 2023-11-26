using FlightScheduler.Contracts;
using FlightScheduler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightScheduler.Services
{
    /// <summary>
    /// An implementation of the <see cref="IOrderService"/>
    /// </summary>
    public class OrderService : IOrderService
    {
        /// <inheritdoc cref="IOrderService.GetOrders"/>
        public Task<IDictionary<string, Order>> GetOrders()
        {
            var ordersDictionary = GetOrdersFromJsonFile();
            LoadOtherOrderInfo(ordersDictionary);

            return Task.FromResult(ordersDictionary as IDictionary<string, Order>);
        }

        private Dictionary<string, Order> GetOrdersFromJsonFile()
        {
            var fileName = @"data\orders.json";
            string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(directoryPath, fileName);
            var serializationOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var jsonOrders = File.ReadAllText(filePath);
            var ordersDictionary = JsonSerializer.Deserialize<Dictionary<string, Order>>(jsonOrders, serializationOptions);
            return ordersDictionary;
        }

        private void LoadOtherOrderInfo(Dictionary<string, Order> ordersDictionary)
        {
            foreach (var item in ordersDictionary)
            {
                var order = item.Value;
                order.OrderNumber = item.Key;
                order.Priority = int.Parse(item.Key.Split('-')[1]);
            }
        }
    }
}