using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.API.Models;
using WebCookingBook.API.Service;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;

namespace WebCookingBook.API.DTOModels
{
    //[ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
    [ModelBinder(BinderType = typeof(TypeBinder))]
    public class CreateIngredientDTO
	{
		[Required]
		public string NameIngredient { get; set; } = "Название";
		[Required]
		public int Count { get; set; } = 1;
		[Required]
		public Unit Units { get; set; } = Unit.кг;
	}
}
