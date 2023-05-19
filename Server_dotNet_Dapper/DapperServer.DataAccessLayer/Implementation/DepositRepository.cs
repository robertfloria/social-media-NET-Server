using Dapper;
using DapperServer.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperServer.DataAccessLayer.Models;

namespace DapperServer.DataAccessLayer.Implementation
{
    public class DepositRepository : RepositoryBase, IDepositRepository
    {
        private const string ADD_DEPOSIT = "AddDeposit";

        public DepositRepository(IDbTransaction transaction, IDbConnection connection) : base(transaction, connection) { }

        public async Task AddDeposit(int id_utilizator, int id_category, DepositsRequest addDepositModel)
        {
            DateTime current_date = DateTime.Now;
            var parameters = new DynamicParameters(new
            {
                id_utilizator = id_utilizator,
                id_category = id_category,
                date_time = current_date,
                category = addDepositModel.Category,
                amount = addDepositModel.Amount,
                deposit_period = addDepositModel.Deposit_period,
                currency = addDepositModel.Currency,
                percentage = addDepositModel.Percentage
            });

            await Connection.QueryAsync(
                sql: ADD_DEPOSIT,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task<IEnumerable<Deposits>> GetDeposit(int id_utilizator, int id_category)
        {
            var query = $"SELECT * FROM dbo.Deposits WHERE id_utilizator={id_utilizator} and id_category={id_category}";

            return await Connection.QueryAsync<Deposits>(query);
        }

        public async Task<IEnumerable<Deposits>> GetAllDeposits(int id_utilizator)
        {
            var query = $"SELECT * FROM dbo.Deposits WHERE id_utilizator={id_utilizator}";

            return await Connection.QueryAsync<Deposits>(query);
        }

        public async Task DeleteDeposit(int id_utilizator, DeleteDepositRequest request)
        {
            var query = $"DELETE FROM Deposits WHERE id_utilizator = {id_utilizator} AND id = {request.DepositId} AND id_category = {request.CategoryId}";

            await Connection.QueryAsync(query);
        }
    }
}
