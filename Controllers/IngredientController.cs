using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebCookingBook.API.DTOModels;
using WebCookingBook.DTOModels;
using Microsoft.AspNetCore.JsonPatch;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.API.Controllers
{
	[Route("/api/recipes/{recipeId}/Ingredient")]
	[ApiController]
	public class IngredientController : Controller
	{
		private IApplicationRepository _applicationRepository;
		private IMapper _mapper;

		public IngredientController(IApplicationRepository applicationRepository, IMapper mapper)
		{
			this._applicationRepository = applicationRepository;
			this._mapper = mapper;
		}
		[HttpGet("{ingredientId}", Name = "GetIngredient")]
		public async Task<ActionResult<IngredientDTO>> GetIngredient(int recipeId, int ingredientId)
		{
			var ingredient = await _applicationRepository.GetIngredientAsync(recipeId,ingredientId);
			if (ingredient == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<IngredientDTO>(ingredient));
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<IngredientDTO>>> GetIngredientsAsync(int recipeId)
		{
			if (recipeId == 0)
			{
				var ingredients = await _applicationRepository.GetIngredientsAsync();
				if (ingredients == null)
				{
					return NotFound();
				}
				return Ok(_mapper.Map<IEnumerable<IngredientDTO>>(ingredients));
			}
			else
			{
				var ingredients = await _applicationRepository.GetIngredientsAsync(recipeId);
				if (ingredients == null)
				{
					return NotFound();
				}
				return Ok(_mapper.Map<IEnumerable<IngredientDTO>>(ingredients));
			}
		}
		[HttpPost]
		public async Task<ActionResult<Ingredient>> AddIngredientAsync(int recipeId, CreateIngredientDTO createIngredientDTO)
		{
			if(! await _applicationRepository.ExistsRecipeAsync(recipeId)) return NotFound();
			var ingredient = _mapper.Map<Ingredient>(createIngredientDTO);
			await _applicationRepository.AddIngredientAsync(recipeId, ingredient);
			await _applicationRepository.SaveChangesAsync();
			var ingredientFinnaly = _mapper.Map<IngredientDTO>(ingredient);
			return CreatedAtRoute("GetIngredient", new
			{
                recipeId = recipeId,
                ingredientId = ingredientFinnaly.Id

			}, ingredientFinnaly);
		}

		[HttpPut("{ingredientId}")]
		public async Task<ActionResult<Ingredient>> UpdateRecipe(int recipeId, int ingredientId, UpdateIngredientDTO updateIngredientDTO)
		{
			if (!await _applicationRepository.ExistsRecipeAsync(recipeId) && await _applicationRepository.ExistsIngredienteAsync(ingredientId))
			{
				return NotFound();
			}
			var ingredient = await _applicationRepository.GetIngredientAsync(recipeId, ingredientId);
			_mapper.Map(updateIngredientDTO, ingredient);
			_applicationRepository.UpdateIngredientAsync(ingredient);
			await _applicationRepository.SaveChangesAsync();
			return NoContent();
		}

		[HttpPatch("{ingredientId}")]
		public async Task<ActionResult<Ingredient>> UpdateRecipe(int recipeId, int ingredientId, JsonPatchDocument<UpdateIngredientDTO> patchDocument)
		{
			if (!await _applicationRepository.ExistsRecipeAsync(recipeId) && await _applicationRepository.ExistsIngredienteAsync(ingredientId))
			{
				return NotFound();
			}
			var ingredient = await _applicationRepository.GetIngredientAsync(recipeId, ingredientId);

			var ingredientPatch = _mapper.Map<UpdateIngredientDTO>(ingredient);

			patchDocument.ApplyTo(ingredientPatch, ModelState);

			if (!TryValidateModel(ingredientPatch))
			{
				return ValidationProblem(ModelState);
			}

			_mapper.Map(ingredientPatch, ingredient);
			_applicationRepository.UpdateIngredientAsync(ingredient);
			await _applicationRepository.SaveChangesAsync();

			return NoContent();
		}
		[HttpDelete("{ingredientId}")]
		public async Task<ActionResult<Ingredient>> DeleteIngredient(int recipeId, int ingredientId)
		{
			if (!await _applicationRepository.ExistsIngredienteAsync(ingredientId))
			{
				return NotFound();
			}
			var recipe = await _applicationRepository.GetIngredientAsync(recipeId, ingredientId);
			_applicationRepository.DeleteIngredientAsync(recipeId, recipe);
			await _applicationRepository.SaveChangesAsync();
			return NoContent();
		}
	}
}
