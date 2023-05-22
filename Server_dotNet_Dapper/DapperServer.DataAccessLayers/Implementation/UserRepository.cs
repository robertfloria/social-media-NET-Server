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
    public class UserRepository : RepositoryBase, IUserRepository
    {
        private const string ADD_USER = "AddUser";

        public UserRepository(IDbTransaction transaction, IDbConnection connection) : base(transaction, connection) { }
        public async Task<AuthenticateResponse> GetUserByUsername(string username)
        {
            var query = $"SELECT * FROM heroku_4b02a80e7cb1159.userregistration WHERE username = '{username}'";

            return await Connection.QueryFirstOrDefaultAsync<AuthenticateResponse>(query, transaction: Transaction);
        }

        public async Task<AuthenticateResponse> GetUserById(int id)
        {
            var query = $"SELECT * FROM heroku_4b02a80e7cb1159.userregistration WHERE id = {id}";

            return await Connection.QueryFirstOrDefaultAsync<AuthenticateResponse>(query, transaction: Transaction);
        }

        public async Task<IEnumerable<AuthenticateResponse>> GetUsers()
        {
            var query = $"SELECT * FROM heroku_4b02a80e7cb1159.userregistration";

            return await Connection.QueryAsync<AuthenticateResponse>(query, transaction: Transaction);
        }

        public async Task<IEnumerable<SearchUsersResponse>> SearchUsers(string username)
        {
            var query = $"SELECT id, username FROM heroku_4b02a80e7cb1159.userregistration WHERE username LIKE '%{username}%'";

            return await Connection.QueryAsync<SearchUsersResponse>(query, transaction: Transaction);
        }

        public async Task<IEnumerable<SearchUsersResponse>> GetAllUsers()
        {
            var query = $"SELECT id, username FROM heroku_4b02a80e7cb1159.userregistration";

            return await Connection.QueryAsync<SearchUsersResponse>(query, transaction: Transaction);
        }

        public async Task UpdateUsername(int id, UpdateUsernameRequest model)
        {
            var query = $"UPDATE heroku_4b02a80e7cb1159.userregistration SET username = '{model.Username}' WHERE id = {id}";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task UpdatePassword(int id, UpdatePasswordRequest model)
        {
            var query = $"UPDATE heroku_4b02a80e7cb1159.userregistration SET password = '{model.Password}' WHERE id = {id}";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task UpdateEmail(int id, UpdateEmailRequest model)
        {
            var query = $"UPDATE heroku_4b02a80e7cb1159.userregistration SET email = '{model.Email}' WHERE id = {id}";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task DeleteUser(int id)
        {
            var query = $"DELETE FROM heroku_4b02a80e7cb1159.userregistration WHERE id = {id}";

            await Connection.QueryAsync(query, transaction: Transaction);
        }

        public async Task AddUser(AuthenticateResponse request)
        {
            var parameters = new DynamicParameters(new
            {
                username = request.Username,
                password = request.Password,
                email = request.Email,
                authority = request.Authority
            });

            await Connection.QueryAsync(
                sql: ADD_USER,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }
    }
}
