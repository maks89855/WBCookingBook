using System.ComponentModel.DataAnnotations;
using WebCookingBook.API.Models;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;

namespace WebCookingBook.API.DTOModels
{
	public class CreateIngredientDTO
	{
		public string NameIngredient { get; set; }
		public int Count { get; set; }
		public Unit Units { get; set; }
	}
}
