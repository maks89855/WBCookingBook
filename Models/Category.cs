using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCookingBook.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string NameCategory { get; set; }
        public ICollection<Recipe> Recipes { get; set; } = new List<Recipe> { };
        public Category()
        {
            this.NameCategory = "Category";
        }
    }
}