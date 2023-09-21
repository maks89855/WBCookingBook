using WebCookingBook.DTOModels;
using WebCookingBook.Models;

namespace WebCookingBook.Service
{
    public interface IApplicationRepository
    {
        Task<bool> SaveChangesAsync();
        #region Category

        Task<Category> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task AddCategoryAsync (Category category);


        #endregion
        #region Recipe

        Task<Recipe> GetRecipeAsync(int categoryId, int recipeId);
        Task<IEnumerable<Recipe>> GetRecipesAsync(int categoryId);
        Task AddRecipeAsync(int categoryId, Recipe recipe);

        #endregion
    }
}
