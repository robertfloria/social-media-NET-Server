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
    public class CurrencyRepository : RepositoryBase, ICurrencyRepository
    {
        private const string EXCHANGE_RATE = "ExchangeRate";

        public CurrencyRepository(IDbTransaction transaction, IDbConnection connection) : base(transaction, connection) { }

        public async Task ExchangeRate(ExchangeRateModel request)
        {
            var parameters = new DynamicParameters(new
            {
                id_utilizator = request.Id_utilizator,
                currency = request.Currency,
                value = request.Value
            });

            await Connection.QueryAsync(
                sql: EXCHANGE_RATE,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task UpdateCurrency(UpdateCurrencyModel request)
        {
            var query = $"UPDATE Currency SET value = {request.Value} WHERE currency = {request.CurrencyName}";

            await Connection.QueryAsync(query);
        }

        public async Task<IEnumerable<CurrencyModel>> GetCurrency()
        {
            var query = "SELECT * FROM Currency";

            return await Connection.QueryAsync<CurrencyModel>(query);
        }
    }
}
