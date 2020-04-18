using Doublelives.Domain.Users.Dto;
using Doublelives.Domain.WorkContext;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using IdentityModel;

namespace Doublelives.Api.Middlewares
{
    public class WorkContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWorkContextAccessor _workContextAccessor;

        public WorkContextMiddleware(RequestDelegate next, IWorkContextAccessor workContextAccessor)
        {
            _next = next;
            _workContextAccessor = workContextAccessor;
        }

        public async Task Invoke(HttpContext context)
        {
            var workContext = new WorkContext
            {
                CurrentUser = GetCurrentUser(context),
            };

            _workContextAccessor.WorkContext = workContext;

            await _next.Invoke(context);
        }

        private CurrentUserDto GetCurrentUser(HttpContext context)
        {
            try
            {
                var userService = context.RequestServices.GetService<IUserService>();
                var userId = context.User.Claims.First(it => it.Type == JwtClaimTypes.Subject).Value;

                var user = userService.GetById(int.Parse(userId)).Result;

                return new CurrentUserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    //Role = user.Role,
                    //Language = user.LanguageCode
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}