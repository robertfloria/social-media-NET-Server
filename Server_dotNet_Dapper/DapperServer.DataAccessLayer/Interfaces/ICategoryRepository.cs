using DapperServer.DataAccessLayer.Models;

namespace DapperServer.DataAccessLayer.Interfaces
{
    public interface ICategoryRepository
    {
        Task UpdateCategory(int id, int categoryId);
        Task UpdateCategoryAmount(int id_utilizator, decimal amount, int id_category);
        Task AddCategory(AddCategoryModel categoryModel);
        Task DeleteCategory(int id, int categoryId);
        Task UpdateCategoryPercentage(int id, int categoryId, decimal percentage);
        Task<IEnumerable<CategoryModel>> GetAllCategories(int id);
    }
}
