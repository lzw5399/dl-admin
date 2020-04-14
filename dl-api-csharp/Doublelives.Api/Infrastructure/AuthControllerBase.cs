using Doublelives.Domain.WorkContext;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Infrastructure
{
    [Authorize]
    [ApiController]
    public class AuthControllerBase : ControllerBase
    {
        protected WorkContext WorkContext { get; }

        public AuthControllerBase(IWorkContextAccessor workContextAccessor)
        {
            WorkContext = workContextAccessor.WorkContext;
        }
    }
}
