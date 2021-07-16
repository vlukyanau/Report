using System.Collections.Generic;
using System.Threading.Tasks;
using ReportClients.BLL.DTO;
using ReportClients.DAL.Entities;

namespace ReportClients.BLL.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientEntity>> GetAllClients();
        Task<ClientDto> GetClient(int id);
        Task<bool> Create(ClientDto client);
    }
}
