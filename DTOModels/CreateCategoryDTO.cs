using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;

namespace WebCookingBook.DTOModels
{
    public class CreateCategoryDTO
    {
        [Required]
        [MaxLength(50)]
        public string NameCategory { get; set; } = "Category";
        public ICollection<CreateRecipeDTO>? Recipes { get; set; } = new List<CreateRecipeDTO> { };
    }
}
