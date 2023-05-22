using Dapper;
using DapperServer.DataAccessLayer.Implementation.BaseRepository;
using DapperServer.DataAccessLayer.Interfaces;
using DapperServer.DataAccessLayer.Models;
using System.Data;

namespace DapperServer.DataAccessLayer.Implementation
{
    public class ChatConversationsRepository : RepositoryBase, IChatConversationsRepository
    {
        public ChatConversationsRepository(IDbTransaction transaction, IDbConnection connection) : base(transaction, connection) { }

        private const string SELECT_USERS_CHAT = "SelectUsersChat";
        private const string SELECT_USERS_MESSAGE_LIST = "SelectUsersMessageList";

        public async Task InsertMessage(int id_utilizator, int friend_id, string message, string date)
        {
            var query = $"INSERT INTO heroku_4b02a80e7cb1159.chatconversations(user_id, friend_id, conversation, inserted_date) VALUES({id_utilizator}, {friend_id}, '{message}', '{date}')";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task<IEnumerable<ChatConversationsResponse>> SelectUsersConversation(int user_id, int friend_id)
        {
            var parameters = new DynamicParameters(new
            {
                user_id,
                friend_id
            });

            return await Connection.QueryAsync<ChatConversationsResponse>(
                sql: SELECT_USERS_CHAT,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task<IEnumerable<UsersMessageListResponse>> SelectUsersMessageList(int user_id)
        {
            var parameters = new DynamicParameters(new
            {
                user_id
            });

            return await Connection.QueryAsync<UsersMessageListResponse>(
                sql: SELECT_USERS_MESSAGE_LIST,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task DeleteUserConversation(int user_id, int friend_id)
        {
            var query = $"DELETE FROM heroku_4b02a80e7cb1159.chatconversations WHERE user_id = {user_id} AND friend_id = {friend_id} " +
                $"DELETE FROM heroku_4b02a80e7cb1159.chatconversations WHERE user_id = {friend_id} AND friend_id = {user_id}";

            await Connection.QueryAsync(query, transaction: Transaction);
        }
    }
}
