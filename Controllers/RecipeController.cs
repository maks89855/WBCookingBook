using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebCookingBook.API.DTOModels;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.Controllers
{
    [Route("api/categories/{categoryId}/recipes")]
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

        [HttpOptions]
        public IActionResult GetRecipeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST");
            return Ok();
        }

        [HttpPut("{recipeId}")]
        public async Task<ActionResult<Recipe>> UpdateRecipe(int categoryId,int recipeId, UpdateRecipeDTO updateRecipeDTO)
        {
            if(!await _applicationRepository.ExistsRecipeAsync(categoryId, recipeId))
            {
                return NotFound();
            }         
            var recipe = await _applicationRepository.GetRecipeAsync(categoryId, recipeId);
            _mapper.Map(updateRecipeDTO, recipe);
            _applicationRepository.UpdateRecipeAsync(recipe);
            await _applicationRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{recipeId}")]
        public async Task<ActionResult<Category>> UpdateCategory(int categoryId, int recipeId, JsonPatchDocument<UpdateRecipeDTO> patchDocument)
        {
            if(!await _applicationRepository.ExistsRecipeAsync(categoryId, recipeId))
            {
                return NotFound();
            }
            var recipe = await _applicationRepository.GetRecipeAsync(categoryId, recipeId);

            var recipePatch = _mapper.Map<UpdateRecipeDTO>(recipe);

            patchDocument.ApplyTo(recipePatch);

            if (!TryValidateModel(recipePatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(recipePatch, recipe);

            _applicationRepository.UpdateRecipeAsync(recipe);
            await _applicationRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
