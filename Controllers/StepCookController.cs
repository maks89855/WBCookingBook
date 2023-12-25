using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebCookingBook.API.DTOModels;
using WebCookingBook.Models;
using WebCookingBook.Service;

namespace WebCookingBook.API.Controllers
{
    [ApiController]
    [Route("api/recipes/{recipeId}/stepCook")]
    public class StepCookController : Controller
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        //TODO: Реализовать методы из репозитория
        public StepCookController(IApplicationRepository repository, IMapper mapper)
        {
            this._applicationRepository = repository;
            this._mapper = mapper;
        }

        [HttpGet("{stepId}",Name = "GetStep")]
        public async Task<ActionResult<StepCookingDTO>> GetStep(int recipeId, int stepId)
        {
            var step = await _applicationRepository.GetStepAsync(recipeId, stepId);
            if (step == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StepCookingDTO>(step));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StepCookingDTO>>> GetSteps(int recipeId)
        {
            var step =  await _applicationRepository.GetStepsRecipeAsync(recipeId);
            if (step == null)
            {
                return NotFound();
            }           
            return Ok(_mapper.Map<IEnumerable<StepCookingDTO>>(step));
        }
        [HttpPost]
        public async Task<ActionResult<CreateStepDTO>> CreateStepCooking(int recipeId, CreateStepDTO createStepDTO)
        {
            if(!await _applicationRepository.ExistsRecipeAsync(recipeId))
            {
                return NotFound();
            }
            var step = _mapper.Map<StepCook>(createStepDTO);
            await _applicationRepository.AddStepAsync(recipeId, step);
            await _applicationRepository.SaveChangesAsync();
            var stepFinnaly = _mapper.Map<StepCookingDTO>(step);
            return CreatedAtRoute("GetStep", new
            {
                recipeId = recipeId,
                stepId = stepFinnaly.Id
            }, stepFinnaly);
        }
    }
}
