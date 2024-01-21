﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.Models;
using WebCookingBook.API.DTOModels;
using Microsoft.AspNetCore.Mvc;

namespace WebCookingBook.DTOModels
{
    public class CreateRecipeDTO
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Превышен лимит символов. Макс. кол-во 50 символов")]
		public string Name { get; set; }
        public IFormFile? Image { get; set; }
		public string? Description { get; set; }
		public ICollection<CreateIngredientDTO> Ingredients { get; set; } = new List<CreateIngredientDTO>();
		public ICollection<CreateStepDTO> StepsCooking { get; set; } = new List<CreateStepDTO>();
    }
}
