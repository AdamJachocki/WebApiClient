using ApliClientLib.Abstractions;
using Common;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApliClientLib.Operations
{
    internal class ClientOperations : IClientOperations
    {
        private readonly HttpClient _httpClient;

        public ClientOperations(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DataResponse<ClientDto>> AddClient(ClientDto data)
        {
            var response = await _httpClient.PostAsJsonAsync("clients", data);
            return await ResponseFactory.CreateDataResponse<ClientDto>(response, DefaultJsonSerializerOptions.Options);
        }

        public async Task<BaseResponse> DeleteClient(int id)
        {
            var response = await _httpClient.DeleteAsync($"clients/{id}");
            return await ResponseFactory.CreateBaseResponse(response);
        }

        public async Task<DataResponse<ClientDto>> GetClientById(int id)
        {
            var response = await _httpClient.GetAsync($"clients/{id}");
            return await ResponseFactory.CreateDataResponse<ClientDto>(response, DefaultJsonSerializerOptions.Options);
        }

        public async Task<DataResponse<GetClientsResultDto>> GetClients(GetClientsRequestDto data)
        {
            var response = await _httpClient.PostAsJsonAsync("clients/all", data);
            return await ResponseFactory.CreateDataResponse<GetClientsResultDto>(response, DefaultJsonSerializerOptions.Options);
        }
    }
}
