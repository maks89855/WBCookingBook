using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCookingBook.DTOModels;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.Controllers
{
    [Route("api/categories")]
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
        public async Task<ActionResult<CategoryDTO>> GetCategoryAsync(
            int categoryId)
        {
            var category = await _applicationRepository.GetCategoryAsync(categoryId);
            if (category == null) 
            { 
                return NotFound(); 
            }
            return Ok(_mapper.Map<CategoryDTO>(category));
        }
        [HttpHead]
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesAsync(
            string? searchCategory)
        {
            var categories = await _applicationRepository.GetCategoriesAsync(searchCategory);
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(CreateCategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _applicationRepository.AddCategoryAsync(category);
            await _applicationRepository.SaveChangesAsync();
            var returnCategory = _mapper.Map<CategoryDTO>(category);
            return CreatedAtRoute("GetCategory", new
            {
                categoryId = category.Id
            }, returnCategory);
        }
        [HttpOptions]
        public IActionResult GetCategoryOptions()
        {
            Response.Headers.Add("Allow", "GET, POST");
            return Ok();
        }
    }
}
