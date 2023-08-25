using Microsoft.EntityFrameworkCore;
using WebCookingBook.DbContexts;
using WebCookingBook.Models;

namespace WebCookingBook.Service
{
    public class ApplicationRepository: IApplicationRepository

    {
        private readonly ApplicationContext _context;

        public ApplicationRepository(ApplicationContext context) 
        {
            this._context = context;
        }

        public Task<Category> AddCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> AddRecipeAsync(int categoryId, int recipeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.Where(c=>c.Id == categoryId).FirstOrDefaultAsync();
        }

        public async Task<Recipe?> GetRecipeAsync(int recipeId)
        {
            return await _context.Recipes.Where(f => f.Id == recipeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync(int categoryId)
        {
            return await _context.Recipes.Where(c=>c.CategoryId == categoryId).ToListAsync();
        }
    }
}
