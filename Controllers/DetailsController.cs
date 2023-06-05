using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Interfaces;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetailsController : CommonConfigurationController
    {
        private readonly ActorDbContext _dbcontext;
        private readonly IDetailsRepository _iDetailsRepository;
        
        public DetailsController(ActorDbContext uPrinceCustomerContext, ActorDbContext dbContext, IHttpContextAccessor contextAccessor, ApiResponse apiResponse, ApiBadRequestResponse apiBadRequestResponse, ApiOkResponse apiOkResponse, IDetailsRepository iDetailsRepository) : base(uPrinceCustomerContext, contextAccessor, apiResponse, apiBadRequestResponse, apiOkResponse)
        {
            _dbcontext = dbContext;
            _iDetailsRepository = iDetailsRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _iDetailsRepository.GetAll();
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }


        [HttpPost]
        public async Task<ActionResult> CreateDetails(Details details)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _iDetailsRepository.CreateDetails(details);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
        
        
        [HttpPut]
        public async Task<ActionResult> UpdateDetails(Details details)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _iDetailsRepository.UpdateDetails(details);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteDetails(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _iDetailsRepository.DeleteDetails(id);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdDetails(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }
        
                var s = await _iDetailsRepository.GeTByIdDetails(id);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
    }
}
