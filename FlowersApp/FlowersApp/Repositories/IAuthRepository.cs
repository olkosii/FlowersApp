using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlowersApp.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> RegisterUser(string email, string password);
        Task<bool> LoginUser(string email, string password);
    }
}
