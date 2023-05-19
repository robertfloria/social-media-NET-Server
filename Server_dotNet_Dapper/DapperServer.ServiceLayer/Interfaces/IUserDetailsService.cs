using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.ServiceLayer.Interfaces
{
    public interface IUserDetailsService
    {
        Task UpdateUserDetails(int user_id, UserDetails request);
        Task<UserDetails> GetUserDetails(int user_id);
    }
}
