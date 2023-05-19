using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface IUserDetailsRepository
    {
        Task InsertUserDetails(int id, UserDetails request);
        Task UpdateUserDetails(int id, UserDetails request);
        Task<UserDetails> GetUserDetails(int id_utilizator);
    }
}
