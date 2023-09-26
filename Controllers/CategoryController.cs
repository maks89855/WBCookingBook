using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public CategoryController(IApplicationRepository applicationRepository, IMapper mapper) 
        {
            this._applicationRepository = applicationRepository;
            this._mapper = mapper;
        }
        [HttpGet("{categoryId}", Name = "GetCategory")]
        public async Task<ActionResult<GetCategoryDTO>> GetCategory(int categoryId)
        {
            var category = await _applicationRepository.GetCategoryAsync(categoryId);
            if (category == null) 
            { 
                return NotFound(); 
            }
            return Ok(_mapper.Map<GetCategoryDTO>(category));
        }
        [HttpHead]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCategoryDTO>>> GetCategoriesAsync()
        {
            var categories = await _applicationRepository.GetCategoriesAsync();
            return Ok(categories);
        }
        [HttpPatch]
        public async Task<ActionResult<Category>> AddCategory(CreateCategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _applicationRepository.AddCategoryAsync(category);
            await _applicationRepository.SaveChangesAsync();
            return CreatedAtRoute("GetCategory", new
            {
                categoryId = category.Id
            });
        }
    }
}
