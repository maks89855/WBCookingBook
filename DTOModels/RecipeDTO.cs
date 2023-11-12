using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.DTOModels
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string Name { get; set; } = "Рецепт";
        public string? Description { get; set; }
		public ICollection<Ingredient>? Ingredients { get; set; }
		public ICollection<StepCook>? StepsCooking { get; set; }

	}
}
