using Dapper;
using DapperServer.DataAccessLayer.Interfaces;
using DapperServer.DataAccessLayer.Models;
using System.Data;

namespace DapperServer.DataAccessLayer.Implementation
{
    public class IncomeRepository : RepositoryBase, IIncomeRepository
    {
        private const string UPDATE_INCOME = "UpdateIncome";
        private const string ADD_INCOME = "AddIncome";

        public IncomeRepository(IDbTransaction transaction, IDbConnection connection) : base(transaction, connection) { }

        public async Task UpdateIncome(int id, decimal newIncome)
        {
            var parameters = new DynamicParameters(new
            {
                id_utilizator = id,
                new_Income = newIncome
            });

            await Connection.QueryAsync(
                sql: UPDATE_INCOME,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task<IEnumerable<IncomeRequest>> GetIncomeById(int id_utilizator)
        {
            var query = $"SELECT * FROM dbo.Income WHERE id_utilizator={id_utilizator}";

            return await Connection.QueryAsync<IncomeRequest>(query);
        }

        public async Task AddIncome(IncomeRequest model)
        {
            var parameters = new DynamicParameters(new
            {
                id_utilizator = model.id_utilizator,
                income = model.income,
                eur = model.eur,
                usd = model.usd
            });

            await Connection.QueryAsync(
                sql: ADD_INCOME,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }
    }
}
