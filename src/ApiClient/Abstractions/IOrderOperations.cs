using Common;
using Models;

namespace ApliClientLib.Abstractions
{
    public interface IOrderOperations
    {
        public Task<DataResponse<OrderDto>> AddOrder(OrderDto order);
        public Task<DataResponse<GetOrdersResultDto>> GetOrdersForClient(int clientId, GetOrdersRequestDto data);
        public Task<DataResponse<GetOrdersResultDto>> GetOrders(GetOrdersResultDto data);
        public Task<BaseResponse> DeleteOrder(int id);
    }
}
