using Microsoft.AspNetCore.Mvc;

namespace WebCookingBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private IFormFile _file;
        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            
            return Ok();
        }
    }
}
