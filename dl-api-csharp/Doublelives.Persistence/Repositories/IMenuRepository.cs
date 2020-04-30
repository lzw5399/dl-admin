using Doublelives.Domain.Sys;
using System.Collections.Generic;

namespace Doublelives.Persistence.Repositories
{
    public interface IMenuRepository : IRepository<SysMenu>
    {
        /// <summary>
        /// 根据roleids获取去重后的权限url
        /// </summary>
        List<string> GetPermissionsByRoleIds(List<int> roleIds, bool activeOnly = true);

        /// <summary>
        /// 根据roleids获取最顶层的菜单
        /// </summary>
        List<SysMenu> GetTopLevelMenusByRoleIds(List<int> roleIds);

        /// <summary>
        /// 根据topmenu.Code获取它的下级菜单
        /// </summary>
        List<SysMenu> GetSubMenusByParentCode(string id);
    }
}