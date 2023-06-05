using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommonConfigurationController : Controller
    {
        protected ApiBadRequestResponse ApiBadRequestResponse;
        protected ApiResponse ApiOkResponse;
        protected ApiResponse ApiResponse;
        //protected IHttpContextAccessor ContextAccessor;
        //protected ITenantProvider ItenantProvider;
        protected ActorDbContext UPrinceCustomerContext;

        public CommonConfigurationController(ActorDbContext uPrinceCustomerContext,
            IHttpContextAccessor contextAccessor, ApiResponse apiResponse
            , ApiBadRequestResponse apiBadRequestResponse, ApiOkResponse apiOkResponse/*, ITenantProvider iTenantProvider*/)
        {
            ApiResponse = apiResponse;
            ApiBadRequestResponse = apiBadRequestResponse;
            ApiOkResponse = apiOkResponse;
            UPrinceCustomerContext = uPrinceCustomerContext;
            //ContextAccessor = contextAccessor;
            //ItenantProvider = iTenantProvider;
        }
    }
}
