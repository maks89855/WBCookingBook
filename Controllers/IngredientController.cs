using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebCookingBook.API.DTOModels;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.API.Controllers
{
	[Route("/api/recipe")]
	public class IngredientController : Controller
	{
		private IApplicationRepository _applicationRepository;
		private IMapper _mapper;

		public IngredientController(IApplicationRepository applicationRepository, IMapper mapper)
        {
			this._applicationRepository = applicationRepository;
			this._mapper = mapper;
		}
		[HttpGet("{recipeId}")]
        public async Task<ActionResult<IngredientDTO>> GetIngredient(int recipeId)
		{
			var ingredient = await _applicationRepository.GetIngredientAsync(recipeId);
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
	}
}
