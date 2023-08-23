using System.ComponentModel.DataAnnotations;

namespace WebCookingBook.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe> { };
        public Category(string nameCategory = "Category")
        {
            this.NameCategory = nameCategory;
        }
    }
}
