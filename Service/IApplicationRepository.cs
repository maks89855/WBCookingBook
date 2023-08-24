using WebCookingBook.Models;

namespace WebCookingBook.Service
{
    public class IApplicationRepository
    {
        #region Category

        Task<Category> GetCategoryAsync;
        Task<IEnumerable<Category>> GetCategoriesAsync;
        Task<Category> AddCategoryAsync;

        #endregion
        #region Recipe

        Task<Recipe> GetRecipeAsync;
        Task<IEnumerable<Recipe>> GetRecipesAsync;
        Task<Recipe> AddRecipeAsync;

        #endregion
    }
}
