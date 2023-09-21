using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;

namespace WebCookingBook.DTOModels
{
    public class GetCategoryDTO
    {
        [Required]
        [MaxLength(50)]
        public string NameCategory { get; set; } = "Category";
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe> { };
        public GetCategoryDTO()
        {
            //this.NameCategory = nameCategory;
        }
    }
}
