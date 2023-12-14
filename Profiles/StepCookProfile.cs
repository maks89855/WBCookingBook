using AutoMapper;
using WebCookingBook.API.DTOModels;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;

namespace WebCookingBook.API.Profiles
{
    public class StepCookProfile: Profile
    {
        public StepCookProfile()
        {
            CreateMap<CreateStepDTO, StepCook>();
            CreateMap<StepCook, StepCookingDTO>();
            CreateMap<StepCookingDTO, StepCook>();
            //CreateMap<UpdateRecipeDTO, StepCook>();
            //CreateMap<StepCook, UpdateRecipeDTO>();
        }
    }
}
