using Doublelives.Domain.Sys;
using System.Collections.Generic;

namespace Doublelives.Persistence.Repositories
{
    public interface IMenuRepository : IRepository<SysMenu>
    {
        List<string> GetPermissionsByRoleIds(List<int> roleIds, bool activeOnly = true);

        List<SysMenu> GetTopLevelMenusByRoleIds(List<int> roleIds);

        List<SysMenu> GetSubMenusByParentCode(string id);
    }
}
