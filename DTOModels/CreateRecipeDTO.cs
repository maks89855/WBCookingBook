using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;

namespace WebCookingBook.DTOModels
{
    public class CreateRecipeDTO
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
