using System.ComponentModel.DataAnnotations;
using WebCookingBook.API.Models;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;

namespace WebCookingBook.API.DTOModels
{
	public class CreateIngredientDTO
	{
		[Required]
		public string NameIngredient { get; set; }
		[Required]
		public int Count { get; set; }
		[Required]
		public Unit Units { get; set; }
	}
}
