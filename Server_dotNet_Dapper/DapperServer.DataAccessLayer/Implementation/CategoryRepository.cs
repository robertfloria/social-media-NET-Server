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
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        private const string UPDATE_CATEGORY = "UpdateCategory";
        private const string UPDATE_CATEGORY_AMOUNT = "UpdateCategoryAmount";
        private const string ADD_CATEGORY = "AddCategory";
        private const string DELETE_CATEGORY = "DeleteCategory";

        public CategoryRepository(IDbTransaction transaction, IDbConnection connection) : base(transaction, connection) { }

        public async Task UpdateCategory(int id, int categoryId)
        {
            var parameters = new DynamicParameters(new
            {
                Id_utilizator = id,
                Id_category = categoryId
            });

            await Connection.QueryAsync(
                sql: UPDATE_CATEGORY,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task UpdateCategoryAmount(int id_utilizator, decimal amount, int id_category)
        {
            var parameters = new DynamicParameters(new
            {
                Id_utilizator = id_utilizator,
                Id_category = amount,
                Amount = id_category
            });

            await Connection.QueryAsync(
                sql: UPDATE_CATEGORY_AMOUNT,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task AddCategory(AddCategoryModel categoryModel)
        {
            var parameters = new DynamicParameters(new
            {
                id_utilizator = categoryModel.Id_utilizator,
                date_time = categoryModel.Date_time,
                category = categoryModel.Category,
                amount = categoryModel.Amount,
                percentage = categoryModel.Percentage
            });

            await Connection.QueryAsync(
                sql: ADD_CATEGORY,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task DeleteCategory(int id, int categoryId)
        {
            var parameters = new DynamicParameters(new
            {
                id_utilizator = id,
                id_category = categoryId,
            });

            await Connection.QueryAsync(
                sql: DELETE_CATEGORY,
                param: parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60,
                transaction: Transaction
                );
        }

        public async Task UpdateCategoryPercentage(int id, int categoryId, decimal percentage)
        {
            var query = $"UPDATE Categories SET [percentage] = {percentage} WHERE id_utilizator = {id} AND id = {categoryId}";

            await Connection.QueryAsync(query);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategories(int id)
        {
            var query = $"SELECT * FROM Categories WHERE id_utilizator={id}";

            return await Connection.QueryAsync<CategoryModel>(query);
        }
    }
}
