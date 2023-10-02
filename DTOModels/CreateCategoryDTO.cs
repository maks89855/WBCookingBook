using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;
using WebCookingBook.API.ValidationAttributes;

namespace WebCookingBook.DTOModels
{
    [CategoryDoesntContainAttribute(ErrorMessage = "Нельзя создать категорию с таким названием, попробуйте другое")]
    public class CreateCategoryDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string NameCategory { get; set; } = "Категория";
        public ICollection<CreateRecipeDTO>? Recipes { get; set; } = new List<CreateRecipeDTO> { };
    }
}
