using ApliClientLib.Abstractions;
using ApliClientLib.Operations;

namespace ApliClientLib
{
    public class ApiClient : IApiClient
    {
        public IClientOperations ClientOperations { get; private set; }
        public IOrderOperations OrderOperations { get; private set; }

        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            ClientOperations = new ClientOperations(_httpClient);
            OrderOperations = new OrderOperations(_httpClient);
        }
    }
}