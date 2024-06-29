using ProjektBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBackend.Core.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Clients> GetAllClients();
        Clients GetClientById(int clientId);
        void AddClient(Clients client);
    }
}
