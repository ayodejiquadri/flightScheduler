using FlightScheduler.Initialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace FlightScheduler
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddAppServices(builder.Configuration);

            using IHost host = builder.Build();

            var inventoryManagerApplication = host.Services.GetRequiredService<InventoryManagementApplication>();
            await inventoryManagerApplication.Run();
        }
    }
}