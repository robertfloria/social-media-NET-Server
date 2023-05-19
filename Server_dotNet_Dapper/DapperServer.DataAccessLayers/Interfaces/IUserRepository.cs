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
        Task<AuthenticateResponse> GetUserByUsername(string username);
        Task<IEnumerable<AuthenticateResponse>> GetUsers();
        Task AddUser(AuthenticateResponse request);
        Task<AuthenticateResponse> GetUserById(int id);
        Task UpdateUsername(int id, UpdateUsernameRequest model);
        Task UpdatePassword(int id, UpdatePasswordRequest model);
        Task UpdateEmail(int id, UpdateEmailRequest model);
        Task<IEnumerable<SearchUsersResponse>> SearchUsers(string username);
        Task DeleteUser(int id);
        Task<IEnumerable<SearchUsersResponse>> GetAllUsers();
    }
}
