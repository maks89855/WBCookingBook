using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebCookingBook.API.Service;

namespace WebCookingBook.API.DTOModels
{
    [ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
    public class UpdateStepDTO
    {
        [Required]
        public int NumberStep { get; set; }
        [Required]
        public string Discription { get; set; }
    }
}
