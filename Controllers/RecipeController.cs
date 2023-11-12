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
    [Route("api/recipes")]
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
        public async Task<ActionResult<RecipeDTO>> GetRecipe(int recipeId)
        {
            var recipe = await _applicationRepository.GetRecipeAsync(recipeId);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<RecipeDTO>(recipe));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDTO>>> GetRecipesAsync(string? searchRecipe)
        {
            var recipe = await _applicationRepository.GetRecipesAsync(searchRecipe);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<RecipeDTO>>(recipe));
        }      

        [HttpPost]
        public async Task<ActionResult<Recipe>> AddRecipeAsync(int categoryId, CreateRecipeDTO createRecipeDTO)
        {
            var recipe = _mapper.Map<Recipe>(createRecipeDTO);
            await _applicationRepository.AddRecipeAsync(categoryId, recipe);
            await _applicationRepository.SaveChangesAsync();
            var categoryFinnaly = _mapper.Map<RecipeDTO>(recipe);
            return CreatedAtRoute("GetRecipe", new
            {              
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
        public async Task<ActionResult<Recipe>> UpdateRecipe(int recipeId, UpdateRecipeDTO updateRecipeDTO)
        {
            if(!await _applicationRepository.ExistsRecipeAsync(recipeId))
            {
                return NotFound();
            }         
            var recipe = await _applicationRepository.GetRecipeAsync(recipeId);
            _mapper.Map(updateRecipeDTO, recipe);
            _applicationRepository.UpdateRecipeAsync(recipe);
            await _applicationRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{recipeId}")]
        public async Task<ActionResult<Category>> UpdateCategory(int recipeId, JsonPatchDocument<UpdateRecipeDTO> patchDocument)
        {
            if(!await _applicationRepository.ExistsRecipeAsync(recipeId))
            {
                return NotFound();
            }
            var recipe = await _applicationRepository.GetRecipeAsync(recipeId);

            var recipePatch = _mapper.Map<UpdateRecipeDTO>(recipe);

            patchDocument.ApplyTo(recipePatch, ModelState);

            if (!TryValidateModel(recipePatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(recipePatch, recipe);

            _applicationRepository.UpdateRecipeAsync(recipe);
            await _applicationRepository.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{recipeId}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int recipeId)
        {
            if (!await _applicationRepository.ExistsRecipeAsync(recipeId))
            {
                return NotFound();
            }
            var recipe = await _applicationRepository.GetRecipeAsync(recipeId);
            _applicationRepository.DeleteRecipeAsync(recipe);
            await _applicationRepository.SaveChangesAsync();
            return NoContent();
        }
       
    }
}
