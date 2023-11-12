using System.ComponentModel.DataAnnotations.Schema;
using WebCookingBook.API.Models;
using WebCookingBook.Models;

namespace WebCookingBook.API.DTOModels
{
	public class IngredientDTO
	{
		public int Id { get; set; }
		public int RecipeId { get; set; }
		public Recipe? Recipe { get; set; }
		public string NameIngredient { get; set; }
		public int Count { get; set; }
		public Unit Units { get; set; }
	}
}
