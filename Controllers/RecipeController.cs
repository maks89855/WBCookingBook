using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.Controllers
{
    [Route("api/category/{categoryId}/recipes")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public RecipeController(IApplicationRepository applicationRepository, IMapper mapper)
        {
            this._applicationRepository = applicationRepository;
            this._mapper = mapper;
        }
        [HttpGet("{recipeId}", Name = "GetRecipe")]
        public async Task<ActionResult<RecipeDTO>> GetRecipe(int categoryId,int recipeId)
        {
            var category = await _applicationRepository.GetCategoryAsync(categoryId);
            if(category == null)
            {
                return NotFound();
            }
            var recipe = await _applicationRepository.GetRecipeAsync(categoryId, recipeId);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RecipeDTO>(recipe));
        }
        [HttpHead]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetRecipesAsync(int categoryId, string? searchRecipe)
        {
            var recipe = await _applicationRepository.GetRecipesAsync(categoryId, searchRecipe);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<RecipeDTO>>(recipe));
        }
        [HttpPost]
        public async Task<ActionResult<Recipe>> AddRecipeAsync(int categoryId,CreateRecipeDTO createRecipeDTO)
        {
            if(!await _applicationRepository.ExistsCategoryAsync(categoryId)) return NotFound();
            var recipe = _mapper.Map<Recipe>(createRecipeDTO);
            await _applicationRepository.AddRecipeAsync(categoryId, recipe);
            await _applicationRepository.SaveChangesAsync();
            var categoryFinnaly = _mapper.Map<RecipeDTO>(recipe);
            return CreatedAtRoute("GetRecipeAsync", new
            {
                categoryId = categoryId,
                recipeId = categoryFinnaly.Id

            }, categoryFinnaly);
        }
    }
}
