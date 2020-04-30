using Doublelives.Api.Models;
using Doublelives.Domain.WorkContext;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Doublelives.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public abstract class AuthControllerBase : ControllerBase
    {
        protected WorkContext WorkContext { get; }

        public AuthControllerBase(IWorkContextAccessor workContextAccessor)
        {
            WorkContext = workContextAccessor.WorkContext;
        }

        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            var response = new ResponseBase
            {
                Data = value
            };

            return base.Ok(response);
        }
    }
}