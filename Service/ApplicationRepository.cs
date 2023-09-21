using Microsoft.EntityFrameworkCore;
using WebCookingBook.DbContexts;
using WebCookingBook.DTOModels;
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

        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
        }

        public async Task AddRecipeAsync(int categoryId, Recipe recipe)
        {
            var category = await GetCategoryAsync(categoryId);
            if (category != null)
            {
                category.Recipes.Add(recipe);
            }
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.Where(c=>c.Id == categoryId).FirstOrDefaultAsync();
        }

        public async Task<Recipe?> GetRecipeAsync(int categoryId, int recipeId)
        {
            return await _context.Recipes.Where(f =>f.CategoryId == categoryId && f.Id == recipeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync(int categoryId)
        {
            return await _context.Recipes.Where(c=>c.CategoryId == categoryId).ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}
