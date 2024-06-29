using ProjektBackend.Core.Entities;
using ProjektBackend.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBackend.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDBContext _context;

        public ClientRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Clients> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Clients GetClientById(int clientId)
        {
            return _context.Clients.Find(clientId);
        }

        public void AddClient(Clients client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
    }
}
