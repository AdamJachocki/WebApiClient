using ApliClientLib.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApliClientLib.Extensions
{
    public class ApiClientOptions
    {
        public const string CONFIG_SECTION = "ApiClientOptions";
        public string BaseAddress { get; set; }
    }
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services, IConfiguration config)
        {
            ApiClientOptions options = config.GetSection(ApiClientOptions.CONFIG_SECTION).Get<ApiClientOptions>();

            services.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                client.BaseAddress = new Uri(options.BaseAddress);
            });

            return services;
        }
    }
}
