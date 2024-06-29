using ProjektBackend.Core.Entities;
using ProjektBackend.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektBackend.Core.Interfaces;

namespace ProjektBackend.Application.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Clients> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public Clients GetClientById(int clientId)
        {
            return _clientRepository.GetClientById(clientId);
        }

        public void AddClient(Clients client)
        {
            _clientRepository.AddClient(client);
        }
    }

}
