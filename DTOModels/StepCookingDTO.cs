using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;

namespace WebCookingBook.API.DTOModels
{
    public class StepCookingDTO
    {
        public int Id { get; set; }
        [Required]
        public int NumberStep { get; set; }
        public int RecipeId { get; set; }
        [Required]
        public string Discription { get; set; }
    }
}
