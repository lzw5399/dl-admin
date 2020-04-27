using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Exceptions;
using Doublelives.Persistence;
using Doublelives.Service.Mappers;
using Doublelives.Service.Users;
using System.Collections.Generic;
using System.Linq;

namespace Doublelives.Service.Menus
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public MenuService(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        /// <summary>获取当前用户拥有的角色,所对应的权限路由</summary>
        public List<RouterDto> GetMenuRouterList(int userid)
        {
            var user = _userService.GetById(userid).Result;
            if (user == null) throw new UserNotFoundException();

            if (string.IsNullOrEmpty(user.Roleid)) return new List<RouterDto>();

            var ids = user.Roleid.Split(',').Select(id => int.Parse(id)).ToList();
            var topMenus = _unitOfWork.MenuRepository.GetTopLevelMenusByRoleIds(ids);

            var dtos = new List<RouterDto>();
            foreach (var topMenu in topMenus)
            {
                var subMenus = _unitOfWork.MenuRepository.GetSubMenusByParentCode(topMenu.Code);
                var dto = MenuMapper.ToRouterDto(topMenu, subMenus);

                dtos.Add(dto);
            }
            dtos = dtos.OrderBy(it => it.Num).ToList();

            return dtos;
        }
    }
}
