using Dapper;
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
        public async Task<IEnumerable<AuthenticateResponse>> GetUserByUsername(string username)
        {
            var query = $"SELECT * FROM UserCredentials WHERE username = {username}";

            return await Connection.QueryAsync<AuthenticateResponse>(query);
        }

        public async Task<IEnumerable<AuthenticateResponse>> GetUserById(int id)
        {
            var query = $"SELECT * FROM UserCredentials WHERE id = {id}";

            return await Connection.QueryAsync<AuthenticateResponse>(query);
        }

        public async Task<IEnumerable<AuthenticateResponse>> GetUsers()
        {
            var query = $"SELECT * FROM UserCredentials";

            return await Connection.QueryAsync<AuthenticateResponse>(query);
        }

        public async Task UpdateUsername(int id, UpdateUsernameRequest model)
        {
            var query = $"UPDATE dbo.UserCredentials SET username = {model.Username} WHERE id = {id}";

            await Connection.QueryAsync(query);
        }

        public async Task UpdatePassword(int id, UpdatePasswordRequest model)
        {
            var query = $"UPDATE dbo.UserCredentials SET password = {model.Password} WHERE id = {id}";

            await Connection.QueryAsync(query);
        }

        public async Task UpdateEmail(int id, UpdateEmailRequest model)
        {
            var query = $"UPDATE dbo.UserCredentials SET email = {model.Email} WHERE id = {id}";

            await Connection.QueryAsync(query);
        }

        public async Task DeleteUser(int id)
        {
            var query = $"DELETE FROM dbo.UserCredentials WHERE id = {id}";

            await Connection.QueryAsync(query);
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
