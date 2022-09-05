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
    internal class OrderOperations : IOrderOperations
    {
        private readonly HttpClient _httpClient;

        public OrderOperations(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DataResponse<OrderDto>> AddOrder(OrderDto order)
        {
            var response = await _httpClient.PostAsJsonAsync("orders", order);
            return await ResponseFactory.CreateDataResponse<OrderDto>(response, DefaultJsonSerializerOptions.Options);
        }

        public async Task<BaseResponse> DeleteOrder(int id)
        {
            var response = await _httpClient.DeleteAsync($"orders/{id}");
            return await ResponseFactory.CreateBaseResponse(response);
        }

        public async Task<DataResponse<GetOrdersResultDto>> GetOrders(GetOrdersResultDto data)
        {
            var response = await _httpClient.PostAsJsonAsync("orders/all", data);
            return await ResponseFactory.CreateDataResponse<GetOrdersResultDto>(response, DefaultJsonSerializerOptions.Options);
        }

        public async Task<DataResponse<GetOrdersResultDto>> GetOrdersForClient(int clientId, GetOrdersRequestDto data)
        {
            var response = await _httpClient.PostAsJsonAsync($"orders/client/{clientId}", data);
            return await ResponseFactory.CreateDataResponse<GetOrdersResultDto> (response, DefaultJsonSerializerOptions.Options);
        }
    }
}
