using Microsoft.AspNetCore.Mvc;
using ReportClients.Api.Model;
using ReportClients.DAL.Entities;
using ReportClients.DAL.Interfaces;
using System;
using System.Threading.Tasks;
using ReportClients.BLL.DTO;
using ReportClients.BLL.Interfaces;

namespace ReportClients.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientServiceController : ControllerBase
    {
        private readonly IClientService _client;

        public ClientServiceController(IClientService clientService)
        {
            _client = clientService;
        }

        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient(ClientModel client)
        {
            if (await _client.Create(new ClientDto()
            {
                ClientName = client.ClientName,
                Id = client.Id,
                ClientCode = client.ClientCode
            }))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Error add client");
            }
        }
        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClients()
        {
            var clientsToList = await _client.GetAllClients();
            return new JsonResult(clientsToList);
        }

        [HttpGet("GetClient")]
        public async Task<IActionResult> GetClient(int id)
        {
            return new JsonResult(await _client.GetClient(id));
        }

    }
}
