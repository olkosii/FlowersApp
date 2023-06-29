using FlowersApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlowersApp.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientsAsync();
        Task<bool> CreateClientAsync(Client client);
        Task<bool> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(Client client);
    }
}
