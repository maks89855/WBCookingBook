using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;

namespace WebCookingBook.DTOModels
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "Recipe";
        public string? Description { get; set; }
        public string? Ingredients { get; set; }
        public string? PreparationMethod { get; set; }

    }
}
