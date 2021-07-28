using Microsoft.AspNetCore.Mvc;
using ReportClients.Api.Model;
using System.Threading.Tasks;
using ReportClients.BLL.DTO;
using ReportClients.BLL.Interfaces;

namespace ReportClients.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _client;

        public ClientsController(IClientService clientService)
        {
            _client = clientService;
        }

        // GET /clients
        [HttpGet]
        public async Task<ActionResult> GetClients()
        {
            await Task.Delay(10000);
            var clientsToList = await _client.GetAllClientsAsync();
            return new JsonResult(clientsToList);
        }

        // GET /clients/id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClients(int id)
        {
            return new JsonResult(await _client.GetClientAsync(id));
        }

        // POST clients
        [HttpPost]
        public async Task<ActionResult<ClientModel>> PostClients(ClientModel client)
        {
            await _client.CreateAsync(new ClientDto()
            {
                ClientName = client.ClientName,
                Id = client.Id,
                ClientCode = client.ClientCode
            });
            return new JsonResult(client);
        }

        // PUT clients
        [HttpPut]
        public JsonResult PutClients(ClientModel client)
        {
          _client.Update(new ClientDto()
            {
                Id = client.Id,
                ClientName = client.ClientName,
                ClientCode = client.ClientCode,
            });
            return new JsonResult(client);
        }

        // DELETE /clients/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClients(int id)
        {
            var client = await _client.GetClientAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            else
            {
               await _client.Delete(id);
            }

            return new JsonResult(client);
        }
    }
}
