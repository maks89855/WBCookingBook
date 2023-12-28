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
        public string? Image { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
        public int CategoryId { get; set; } = 1;
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<StepCook>? StepsCooking { get; set; } = new List<StepCook>();

        public Recipe()
        {
            this.Name = "Рецепт";
        }
    }
}
