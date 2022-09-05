using Common;
using Models;

namespace ApliClientLib.Abstractions
{
    public interface IClientOperations
    {
        public Task<DataResponse<ClientDto>> AddClient(ClientDto data);
        public Task<DataResponse<GetClientsResultDto>> GetClients(GetClientsRequestDto data);
        public Task<DataResponse<ClientDto>> GetClientById(int id);
        public Task<BaseResponse> DeleteClient(int id);
    }
}
