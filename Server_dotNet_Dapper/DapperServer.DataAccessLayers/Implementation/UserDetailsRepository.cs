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
    public class UserDetailsRepository : RepositoryBase, IUserDetailsRepository
    {
        public UserDetailsRepository(IDbTransaction transaction, IDbConnection connection) : base(transaction, connection) { }

        private const string ADD_USER_DETAILS = "AddUserDetails";
        private const string UPDATE_USER_DETAILS = "UpdateUserDetails";

        public async Task InsertUserDetails(int id, UserDetails request)
        {
            var parameters = new DynamicParameters(new
            {
                user_id = id,
                full_name = request.Full_name,
                country = request.Country,
                city = request.City,
                email = request.Email,
                education = request.Education,
                birthday = request.Birthday,
            });

            await Connection.QueryAsync(
                sql: ADD_USER_DETAILS,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task UpdateUserDetails(int id, UserDetails request)
        {
            var parameters = new DynamicParameters(new
            {
                user_id = id,
                full_name = request.Full_name,
                country = request.Country,
                city = request.City,
                email = request.Email,
                education = request.Education,
                birthday = request.Birthday,
            });

            await Connection.QueryAsync(
                sql: UPDATE_USER_DETAILS,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task<UserDetails> GetUserDetails(int id_utilizator)
        {
            var query = $"SELECT user_id, full_name, country, city, email, education, birthday from heroku_4b02a80e7cb1159.userdetails WHERE user_id = '{id_utilizator}'";

            return await Connection.QueryFirstAsync<UserDetails>(query, transaction: Transaction);
        }
    }
}
