using Dapper;
using DapperServer.DataAccessLayer.Implementation.BaseRepository;
using DapperServer.DataAccessLayer.Interfaces;
using DapperServer.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperServer.DataAccessLayer.Implementation
{
    public class UserFollowRepository : RepositoryBase, IUserFollowRepository
    {
        public UserFollowRepository(IDbTransaction transaction, IDbConnection connection) : base(transaction, connection) { }

        private const string SELECT_USER_FRIENDS = "SelectUserFriends";

        public async Task InsertUserFollow(int id_utilizator, int friend_id)
        {
            var query = $"INSERT INTO UserFollow(user_id, friend_id) VALUES({id_utilizator}, {friend_id})";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task DeleteUserFollow(int id_utilizator, int friend_id)
        {
            var query = $"DELETE FROM UserFollow WHERE user_id = {id_utilizator} AND friend_id = {friend_id}";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task<IEnumerable<UserFollowResponse>> SelectUserFriends(int id)
        {
            var parameters = new DynamicParameters(new
            {
                user_id = id,
            });

            return await Connection.QueryAsync<UserFollowResponse>(
                sql: SELECT_USER_FRIENDS,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }
    }
}
