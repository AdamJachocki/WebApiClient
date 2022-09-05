using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddScoped<IHostedService, Application>();

                    services.AddSingleton<Startup>();
                    var provider = services.BuildServiceProvider();

                    var startup = provider.GetRequiredService<Startup>();
                    startup.ConfigureServices(services);
                })
                .ConfigureHostConfiguration(config =>
                {
                    var configFilePath = Path.Combine("Properties", "launchSettings.json");
                    config.AddJsonFile(configFilePath);
                })
                .Build();

            await host.StartAsync();

        }
    }
}