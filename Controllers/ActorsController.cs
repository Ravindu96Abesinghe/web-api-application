using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using System;
using WebApplicationApi.Interfaces;
using WebApplicationApi.Migrations;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ActorsController : CommonConfigurationController
    {
        private readonly ActorDbContext _dbcontext;
        private readonly IActorsRepository _iActorsRepository;


        public ActorsController(ActorDbContext dbContext,
                                IActorsRepository iActorsRepository,
                                ActorDbContext uPrinceCustomerContext,
                                IHttpContextAccessor contextAccessor,
                                ApiResponse apiResponse,
                                ApiBadRequestResponse apiBadRequestResponse,
                                ApiOkResponse apiOkResponse)
        : base(uPrinceCustomerContext, contextAccessor, apiResponse, apiBadRequestResponse, apiOkResponse)
            
        {
            _dbcontext = dbContext;
            _iActorsRepository = iActorsRepository;
        }

        //public IActionResult Index()
        //{
        //    return View(_context.Actors.ToList());
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}

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

                var s = await _iActorsRepository.GetAll();
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }


        [HttpPost]
        public async Task<ActionResult> CreateActor(Actors actors)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _iActorsRepository.CreateActor(actors);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
        
        
        [HttpPut]
        public async Task<ActionResult> UpdateActor(Actors actors)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _iActorsRepository.UpdateActor(actors);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteActor(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _iActorsRepository.DeleteActor(id);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdActor(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }
        
                var s = await _iActorsRepository.GeTByIdActor(id);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
    }
}
