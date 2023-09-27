using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;

namespace WebCookingBook.DTOModels
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameCategory { get; set; } = "Category";
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe> { };
        public CategoryDTO()
        {
            //this.NameCategory = nameCategory;
        }
    }
}
