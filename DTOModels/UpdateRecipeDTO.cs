using System.ComponentModel.DataAnnotations;

namespace WebCookingBook.API.DTOModels
{
    public class UpdateRecipeDTO
    {
        //public Image Image { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string Name { get; set; } = "Рецепт";
        public string? Description { get; set; }
        public string? Ingredients { get; set; }
        public string? PreparationMethod { get; set; }
    }
}
