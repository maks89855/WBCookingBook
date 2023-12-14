using AutoMapper;
using WebCookingBook.API.DTOModels;
using WebCookingBook.Models;

namespace WebCookingBook.API.Profiles
{
	public class IngredientProfile : Profile
	{
        public IngredientProfile()
        {
            CreateMap<IngredientDTO, Ingredient>();
            CreateMap<Ingredient, IngredientDTO>();
            CreateMap<CreateIngredientDTO, Ingredient>();
            CreateMap<UpdateIngredientDTO, Ingredient>();
            CreateMap<Ingredient, UpdateIngredientDTO>();
        }
    }
}
