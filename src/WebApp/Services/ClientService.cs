using ApliClientLib.Abstractions;
using Common;
using Models;

namespace WebApp.Services
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

        public async Task<DataResponse<GetClientsResultDto>> GetClients(int offset)
        {
            var request = new GetClientsRequestDto
            {
                Skip = offset,
                Take = 20
            };

            return await _apiClient.ClientOperations.GetClients(request);
        }

        public async Task<BaseResponse> DeleteClient(int id)
        {
            return await _apiClient.ClientOperations.DeleteClient(id);
        }
    }
}
