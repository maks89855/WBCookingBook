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
        Task<IEnumerable<Category>> GetCategoriesAsync(string searchCategory);
        Task AddCategoryAsync (Category category);

        void UpdateCategoryAsync (Category category);
        void DeleteCategoryAsync (Category category);

        Task<bool> ExistsCategoryAsync(int categoryId);
        #endregion

        #region Recipe

        Task<Recipe> GetRecipeAsync(int recipeId);
		Task<IEnumerable<Recipe>> GetRecipesAsync();
		Task<IEnumerable<Recipe>> GetRecipesAsync(string searchRecipe);
        Task AddRecipeAsync(Recipe recipe);
        Task<bool> ExistsRecipeAsync(int recipeId);
        void UpdateRecipeAsync(Recipe recipe);
        void DeleteRecipeAsync(Recipe recipe);

        #endregion
    }
}
