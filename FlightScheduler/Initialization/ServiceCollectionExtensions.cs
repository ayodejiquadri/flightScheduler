using FlightScheduler.Contracts;
using FlightScheduler.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightScheduler.Initialization
{
    /// <summary>
    /// Contains extension methods for adding services to the Service collection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds different services needed during startup
        /// </summary>
        /// <param name="services">An instance of <see cref="IServiceCollection"/></param>
        /// <param name="configuration">An instance of <see cref="IConfiguration"/> for loading app settings</param>
        /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
        public static IServiceCollection AddAppServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IFlightService, FlightService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IInventoryManagerService, InventoryManagerService>()
                .AddScoped<InventoryManagementApplication>();

            return services;
        }
    }
}