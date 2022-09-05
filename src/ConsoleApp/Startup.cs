using ApiClient.Extensions;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApp
{
    internal class Startup
    {
        private readonly IConfiguration _config;
        private readonly ILogger<Startup> _logger;
        public Startup(IConfiguration config, ILogger<Startup> logger)
        {
            _config = config;
            _logger = logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiClient(_config);
            services.AddSingleton<MainMenu>();
            services.AddScoped<ClientService>();
        }
    }
}
