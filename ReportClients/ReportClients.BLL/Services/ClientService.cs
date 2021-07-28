using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<ClientEntity>> GetAllClientsAsync()
        {
            return await _client.GetAllAsync();
        }

        public async Task<ClientDto> GetClientAsync(int id)
        {
            var result =  await _client.GetByIdAsync(id);
            if (result == null)
            {
                throw new InvalidOperationException("Client not found");
            }

            return new ClientDto()
            {
                ClientCode = result.ClientCode,
                ClientName = result.ClientName,
                Id = result.Id
            };
        }

        public async Task CreateAsync(ClientDto client)
        {
            await _client.CreateAsync(new ClientEntity()
            {
                Id = client.Id,
                ClientCode = client.ClientCode,
                ClientName = client.ClientName
            });
        }

        public Task Update(ClientDto client)
        {
            return _client.Update(new ClientEntity()
            {
                ClientName = client.ClientName,
                ClientCode = client.ClientCode,
                Id = client.Id
            });
        }

        public Task Delete(int id)
        {
            return _client.Delete(id);
        }
    }
}