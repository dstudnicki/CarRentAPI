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

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(Clients client)
        {
            _clientService.AddClient(client);
            return Ok();
        }
    }
}
