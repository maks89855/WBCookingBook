using AutoMapper;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;

namespace WebCookingBook.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
