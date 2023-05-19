using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface IChatConversationsRepository
    {
        Task InsertMessage(int id_utilizator, int friend_id, string message, string date);
        Task<IEnumerable<ChatConversationsResponse>> SelectUsersConversation(int user_id, int friend_id);
        Task<IEnumerable<UsersMessageListResponse>> SelectUsersMessageList(int user_id);
        Task DeleteUserConversation(int user_id, int friend_id);
    }
}
