using WebCookingBook.Models;

namespace WebCookingBook.Service
{
    public interface IApplicationRepository
    {
        #region Category

        Task<Category> GetCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> AddCategoryAsync ();

        #endregion
        #region Recipe

        Task<Recipe> GetRecipeAsync(int recipeId);
        Task<IEnumerable<Recipe>> GetRecipesAsync(int categoryId);
        Task<Recipe> AddRecipeAsync(int categoryId, int recipeId);

        #endregion
    }
}
