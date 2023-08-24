using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace WebCookingBook.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //public Image Image { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "Recipe";
        public string? Description { get; set; }
        public string? Ingredients { get; set; }
        public string? PreparationMethod { get; set; }

        public Recipe()
        {
            //this.Name = name;
        }
    }
}
