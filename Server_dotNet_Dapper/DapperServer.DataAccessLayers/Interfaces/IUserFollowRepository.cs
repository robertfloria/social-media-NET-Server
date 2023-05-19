using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface IUserFollowRepository
    {
        Task InsertUserFollow(int id_utilizator, int friend_id);
        Task DeleteUserFollow(int id_utilizator, int friend_id);
        Task<IEnumerable<UserFollowResponse>> SelectUserFriends(int id);
    }
}
