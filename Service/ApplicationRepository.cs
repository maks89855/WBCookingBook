using Microsoft.AspNetCore.Mvc;
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

        public async Task<bool> ExistsCategoryAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c=>c.Id == categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(string searchCategory)
        {
            if (string.IsNullOrWhiteSpace(searchCategory))
            {
                return await GetCategoriesAsync();
            }
            searchCategory = searchCategory.Trim();
            return await _context.Categories.Where(c => c.NameCategory == searchCategory).ToListAsync();
        }
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.Where(c=>c.Id == categoryId).FirstOrDefaultAsync();
        }

        public async Task<Recipe> GetRecipeAsync(int categoryId, int recipeId)
        {
            return await _context.Recipes.Where(f =>f.CategoryId == categoryId && f.Id == recipeId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipesAsync(int categoryId)
        {
            return await _context.Recipes.Where(c=>c.CategoryId == categoryId).ToListAsync();
        }
        public async Task<IEnumerable<Recipe>> GetRecipesAsync(int categoryId,string seacrhRecipe)
        {
            if (string.IsNullOrWhiteSpace(seacrhRecipe)) return await GetRecipesAsync(categoryId);
            seacrhRecipe = seacrhRecipe.Trim();
            return await _context.Recipes.Where(c => c.CategoryId == categoryId && c.Name.Contains(seacrhRecipe)).ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}
