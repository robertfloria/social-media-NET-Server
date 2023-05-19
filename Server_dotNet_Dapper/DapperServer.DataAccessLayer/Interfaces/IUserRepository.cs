using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AuthenticateResponse>> GetUserByUsername(string username);
        Task<IEnumerable<AuthenticateResponse>> GetUsers();
        Task AddUser(AuthenticateResponse request);
        Task<IEnumerable<AuthenticateResponse>> GetUserById(int id);
        Task UpdateUsername(int id, UpdateUsernameRequest model);
        Task UpdatePassword(int id, UpdatePasswordRequest model);
        Task UpdateEmail(int id, UpdateEmailRequest model);
        Task DeleteUser(int id);
    }
}
