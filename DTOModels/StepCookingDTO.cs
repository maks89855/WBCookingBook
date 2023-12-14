using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;

namespace WebCookingBook.API.DTOModels
{
    public class StepCookingDTO
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Discription { get; set; }
    }
}
