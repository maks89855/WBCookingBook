using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using WebCookingBook.API.Service;
using WebCookingBook.Models;

namespace WebCookingBook.API.DTOModels
{
	[ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
	public class CreateStepDTO
    {
        public int NumberStep { get; set; }
        public string Discription { get; set; }
    }
}
