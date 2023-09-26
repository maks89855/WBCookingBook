using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.Controllers
{
    [Route("api/category/{categoryId}/[controller]")]
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
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetRecipesAsync(int categoryId)
        {
            var recipe = await _applicationRepository.GetRecipesAsync(categoryId);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<RecipeDTO>>(recipe));
        }
        [HttpPatch]
        public async Task<ActionResult<Recipe>> AddRecipeAsync(int categoryId,CreateRecipeDTO createRecipeDTO)
        {
            var recipe =  _mapper.Map<Recipe>(createRecipeDTO);
            if(recipe == null) return NotFound();
            await _applicationRepository.AddRecipeAsync(categoryId, recipe);
            await _applicationRepository.SaveChangesAsync();
            var categoryFinnaly = _mapper.Map<RecipeDTO>(recipe);
            return CreatedAtRoute("GetRecipeAsync", new
            {
                categoryId = categoryId,
                recipeId = categoryFinnaly.Id

            });
        }
    }
}
