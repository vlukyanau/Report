using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReportClients.BLL.DTO;
using ReportClients.BLL.Interfaces;
using ReportClients.DAL.Entities;
using ReportClients.DAL.Interfaces;

namespace ReportClients.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly IGenericAsyncRepository<ClientEntity> _client;

        public ClientService(IGenericAsyncRepository<ClientEntity> client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ClientEntity>> GetAllClients()
        {
            return await _client.GetAll();
        }

        public async Task<ClientDto> GetClient(int id)
        {
            var result =  await _client.GetById(id);
            return new ClientDto()
            {
                ClientCode = result.ClientCode,
                ClientName = result.ClientName,
                Id = result.Id
            };
        }

        public async Task<bool> Create(ClientDto client)
        {
            return await _client.Create(new ClientEntity()
            {
                Id = client.Id,
                ClientName = client.ClientName,
                ClientCode = client.ClientCode
            });
        }
    }
}