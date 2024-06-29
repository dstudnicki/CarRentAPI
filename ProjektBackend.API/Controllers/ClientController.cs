using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjektBackend.Application.Services;
using ProjektBackend.Core.Entities;

namespace ProjektBackend.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult GetAll()
        {
            var clients = _clientService.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator,User")]
        public IActionResult GetDetails(int id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Clients client)
        {
            _clientService.AddClient(client);
            return Ok();
        }
    }
}
