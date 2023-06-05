using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Interfaces;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmsController : CommonConfigurationController
    {
        private readonly ActorDbContext _Dbcontext;
        private readonly IFilmsRepository _filmsRepository;

        public FilmsController(ActorDbContext uPrinceCustomerContext, ActorDbContext dbContext,
            IHttpContextAccessor contextAccessor, ApiResponse apiResponse, ApiBadRequestResponse apiBadRequestResponse,
            ApiOkResponse apiOkResponse, IFilmsRepository iFilmsRepository) : base(uPrinceCustomerContext,
            contextAccessor, apiResponse, apiBadRequestResponse, apiOkResponse)
        {
            _Dbcontext = dbContext;
            _filmsRepository = iFilmsRepository;
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

                var s = await _filmsRepository.GetAll();
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }


        [HttpPost]
        public async Task<ActionResult> CreateFilm(Films films)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _filmsRepository.CreateFilm(films);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }


        [HttpPut]
        public async Task<ActionResult> UpdateFilm(Films films)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _filmsRepository.UpdateFilm(films);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteFilm(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _filmsRepository.DeleteFilm(id);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetByNameFilm(string name)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ApiBadRequestResponse.ModelState = ModelState;
                    return BadRequest(ApiBadRequestResponse);
                }

                var s = await _filmsRepository.GetByNameFilm(name);
                return Ok(new ApiOkResponse(s));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, false, ex.Message));
            }
        }
    }
}