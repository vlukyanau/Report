using System.Collections.Generic;
using System.Threading.Tasks;
using ReportClients.BLL.DTO;
using ReportClients.DAL.Entities;

namespace ReportClients.BLL.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientEntity>> GetAllClientsAsync();
        Task<ClientDto> GetClientAsync(int id);
        Task CreateAsync(ClientDto client);
        Task Update(ClientDto client);

        Task Delete(int id);
    }
}
