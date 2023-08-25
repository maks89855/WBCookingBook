using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.Controllers
{
    [Route("api/category/{categoryId}/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;

        public RecipeController(IApplicationRepository applicationRepository)
        {
            this._applicationRepository = applicationRepository;
        }
        [HttpGet("{recipeId}")]
        public async Task<ActionResult<Recipe>> GetRecipeAsync(int recipeId)
        {
            var recipe = await _applicationRepository.GetRecipeAsync(recipeId);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesAsync(int categoryId)
        {
            var category = await _applicationRepository.GetRecipesAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);

        }
    }
}
