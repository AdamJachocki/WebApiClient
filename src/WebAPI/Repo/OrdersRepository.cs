using Models;
using WebAPI.Models;

namespace WebAPI.Repo
{
    public class OrdersRepository
    {
        private Dictionary<int, Order> _dataset = new();

        public int AddOrder(Order data)
        {
            if (data.Id <= 0)
                data.Id = GetNextId();

            _dataset.Add(data.Id, data);

            return data.Id;
        }

        private int GetNextId()
        {
            if (_dataset.Count == 0)
                return 1;
            else
                return _dataset.Max(p => p.Key) + 1;
        }

        public Order GetOrderById(int id)
        {
            Order result = null;
            _dataset.TryGetValue(id, out result);

            return result;
        }

        public IEnumerable<Order> GetOrdersForClient(int clientId, GetOrdersRequestDto filterData)
        {
            return _dataset.Where(x => x.Value.ClientId == clientId && !x.Value.IsDeleted)
                .Skip(filterData.Skip)
                .Take(filterData.Take)
                .Select(x => x.Value);
        }

        public IEnumerable<Order> GetOrders(GetOrdersRequestDto filterData)
        {
            return _dataset.Values.Where(x => !x.IsDeleted)
                .Skip(filterData.Skip)
                .Take(filterData.Take);
        }

        public bool DeleteOrder(int orderId)
        {
            try
            {
                _dataset[orderId].IsDeleted = true;
                return true;
            }catch(KeyNotFoundException)
            {
                return false;
            }
        }
    }
}
