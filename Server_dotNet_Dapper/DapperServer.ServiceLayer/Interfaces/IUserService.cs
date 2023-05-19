using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.ServiceLayer.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task Register(RegisterRequest model);
        Task UpdateUsername(int id, UpdateUsernameRequest model);
        Task UpdatePassword(int id, UpdatePasswordRequest model);
        Task UpdateEmail(int id, UpdateEmailRequest model);
        Task Delete(int id);
        Task<AuthenticateResponse> GetUserById(int id);
        Task<IEnumerable<SearchUsersResponse>> SearchUsers(string username);
        Task<IEnumerable<SearchUsersResponse>> GetAllUsers();
    }
}
