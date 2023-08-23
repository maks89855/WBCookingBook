using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace WebCookingBook.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        //public Image Image { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Ingredients { get; set; }
        public string? PreparationMethod { get; set; }

        public Recipe(string name = "Recipe")
        {
            this.Name = name;
        }
    }
}
