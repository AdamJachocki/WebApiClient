using Models;
using WebAPI.Models;

namespace WebAPI.Repo
{
    public class ClientsRepository
    {
        private Dictionary<int, Client> _dataset = new();

        public int AddClient(Client data)
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

        public Client GetClientById(int id)
        {
            Client result = null;
            _dataset.TryGetValue(id, out result);
            return result;
        }

        public IEnumerable<Client> GetClients(GetClientsRequestDto filterData)
        {
            return _dataset.Values.Where(x => !x.IsDeleted)
                .Skip(filterData.Skip)
                .Take(filterData.Take);
        }

        public bool DeleteClient(int id)
        {
            try
            {
                _dataset[id].IsDeleted = true;
                return true;
            }catch(KeyNotFoundException)
            {
                return false;
            }
            
        }
    }
}
