﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebCookingBook.API.Service;
using WebCookingBook.Models;

namespace WebCookingBook.API.DTOModels
{
	[ModelBinder(BinderType = typeof(MetadataValueModelBinder))]
	public class CreateStepDTO
    {
        [Required]
        public int NumberStep { get; set; }
        [Required]
        public string Discription { get; set; }
    }
}
