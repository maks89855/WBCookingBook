using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;
using WebCookingBook.API.DTOModels;

namespace WebCookingBook.DTOModels
{
    public class CreateRecipeDTO
    {
        //public Image Image { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string Name { get; set; } = "Рецепт";
        public string? Image { get; set; }
        public string? Description { get; set; }
        public ICollection<CreateIngredientDTO>? Ingredients { get; set; } = new List<CreateIngredientDTO>();
        public ICollection<StepCookingDTO>? StepsCooking { get; set; } = new List<StepCookingDTO>();
    }
}
