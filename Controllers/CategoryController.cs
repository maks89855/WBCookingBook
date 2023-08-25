using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;

        public CategoryController(IApplicationRepository applicationRepository) 
        {
            this._applicationRepository = applicationRepository;
        }
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<Category>> GetCategory(int categoryId)
        {
            var category = await _applicationRepository.GetCategoryAsync(categoryId);
            if (category == null) 
            { 
                return NotFound(); 
            }
            return Ok(category);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesAsync()
        {
            var categories = await _applicationRepository.GetCategoriesAsync();
            return Ok(categories);
        }
    }
}
