using ApiClient.Abstractions;
using Common;
using Models;

namespace ConsoleApp.Services
{
    public class ClientService
    {
        private readonly IApiClient _apiClient;

        public ClientService(IApiClient apiClient)
        {
            _apiClient = apiClient; 
        }

        public async Task<DataResponse<ClientDto>> AddClient(ClientDto data)
        {
            return await _apiClient.ClientOperations.AddClient(data);
        }

        public async Task<DataResponse<GetClientsResultDto>> GetClientList(int offset)
        {
            var request = new GetClientsRequestDto
            {
                Skip = offset,
                Take = 10
            };

            return await _apiClient.ClientOperations.GetClients(request);
        }

        public async Task<DataResponse<ClientDto>> GetClient(int clientId)
        {
            return await _apiClient.ClientOperations.GetClientById(clientId);
        }
    }
}
