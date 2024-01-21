using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;
using WebCookingBook.Service;
using WebCookingBook.API.DTOModels;

namespace WebCookingBook.DTOModels
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO? Category { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string Name { get; set; } = "Рецепт";
        public string? Image { get; set; }

		public string? Description { get; set; }
		public ICollection<IngredientDTO>? Ingredients { get; set; } = new List<IngredientDTO>();
		public ICollection<StepCookingDTO>? StepsCooking { get; set; } = new List<StepCookingDTO>();

	}
}
