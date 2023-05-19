using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.ServiceLayer.Interfaces
{
    public interface IUserFollowService
    {
        Task FollowFriend(int user_id, int friend_id);
        Task UnfollowFriend(int user_id, int friend_id);
        Task<IEnumerable<UserFollowResponse>> SelectFriends(int user_id);
    }
}
