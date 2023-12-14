using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebCookingBook.API.Models;
using WebCookingBook.Models;

namespace WebCookingBook.API.DTOModels
{
	public class UpdateIngredientDTO
	{
		[Required]
		public string NameIngredient { get; set; }
		[Required]
		public int Count { get; set; }
		[Required]
		public Unit Units { get; set; }
	}
}
