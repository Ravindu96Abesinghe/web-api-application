using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Interfaces;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class IndrustryController : CommonConfigurationController
    {
        
        private readonly ActorDbContext _dbcontext;
        private readonly IIndrustryRepository _iIndrustryRepository;
        
        public IndrustryController(ActorDbContext uPrinceCustomerContext,ActorDbContext dbcontext, IHttpContextAccessor contextAccessor, ApiResponse apiResponse, ApiBadRequestResponse apiBadRequestResponse, ApiOkResponse apiOkResponse, IIndrustryRepository iIndrustryRepository) : base(uPrinceCustomerContext, contextAccessor, apiResponse, apiBadRequestResponse, apiOkResponse)
        {
            _dbcontext = dbcontext;
            _iIndrustryRepository = iIndrustryRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetActorsFilms()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _iIndrustryRepository.GetActorsFilm();
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
        
        [HttpGet("getDetails")]
        public async Task<ActionResult> GetDetails()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _iIndrustryRepository.GetDetails();
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
    }
}