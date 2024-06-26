using ProjektBackendLab.Core.Entities;
using ProjektBackendLab.Core.Interfaces;
using ProjektBackendLab.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBackendLab.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDBContext _context;

        public ClientRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddClient(Clients client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
    }
}
