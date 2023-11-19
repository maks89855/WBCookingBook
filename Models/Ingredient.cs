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
		[Required]
		public string NameIngredient { get; set; }
		[Required]
		public int Count { get; set; }
		[Required]
		public Unit Units { get; set; }
	}
}