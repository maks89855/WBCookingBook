using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;
using WebCookingBook.API.ValidationAttributes;

namespace WebCookingBook.DTOModels
{
    [CategoryDoesntContainAttribute]
    public class CreateCategoryDTO
    {
        [Required]
        [MaxLength(50)]
        public string NameCategory { get; set; } = "Category";
        public ICollection<CreateRecipeDTO>? Recipes { get; set; } = new List<CreateRecipeDTO> { };
    }
}
