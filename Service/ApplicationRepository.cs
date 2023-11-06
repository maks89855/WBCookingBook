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

        public async Task AddRecipeAsync(Recipe recipe)
        {
  
            _context.Recipes.Add(recipe);

        }

        public void DeleteCategoryAsync(Category category)
        {
            _context.Categories.Remove(category);
        }

        public void DeleteRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Remove(recipe);
        }

        public async Task<bool> ExistsCategoryAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c=>c.Id == categoryId);
        }

        public async Task<bool> ExistsRecipeAsync(int recipeId)
        {
            return await _context.Recipes.AnyAsync(c=> c.Id == recipeId);
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

        public async Task<Recipe> GetRecipeAsync(int recipeId)
        {
            return await _context.Recipes.Where(f =>f.Id == recipeId).FirstOrDefaultAsync();
        }
		public async Task<IEnumerable<Recipe>> GetRecipesAsync()
		{
            return await _context.Recipes.ToListAsync();
		}
        public async Task<IEnumerable<Recipe>> GetRecipesAsync(string seacrhRecipe)
        {
            if (string.IsNullOrWhiteSpace(seacrhRecipe)) return await GetRecipesAsync();
            seacrhRecipe = seacrhRecipe.Trim();
            return await _context.Recipes.Where(c => c.Name.Contains(seacrhRecipe)).ToListAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (_context.SaveChanges()>=0);
        }

        public void UpdateCategoryAsync(Category category)
        {
            
        }

        public void UpdateRecipeAsync(Recipe recipe)
        {
            
        }
    }
}
