using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.API.Models;

namespace WebCookingBook.Models
{
	public class Ingredient
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int RecipeId { get; set; }
		[ForeignKey("RecipeId")]
		public Recipe? Recipe { get; set; }
		public string NameIngredient { get; set; }
		public int Count { get; set; }
		public Unit Units { get; set; }
	}
}