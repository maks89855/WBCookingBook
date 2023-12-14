using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebCookingBook.Models
{
	public class StepCook
	{
		//TODO: Добавить поле int с порядковым номер шага, провести миграцию, добавить поле в DTO модели
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int RecipeId { get; set; }
		[ForeignKey("RecipeId")]
		public Recipe? Recipe { get; set; }
		public string Discription { get; set; }
	}
}