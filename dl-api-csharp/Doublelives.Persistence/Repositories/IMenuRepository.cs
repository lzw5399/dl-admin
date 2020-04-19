using Doublelives.Domain.Sys;
using System.Collections.Generic;

namespace Doublelives.Persistence.Repositories
{
    public interface IMenuRepository : IRepository<SysMenu>
    {
        List<string> GetPermissionsByRoleIds(List<long> roleIds, bool activeOnly = true);

        List<SysMenu> GetTopLevelMenusByRoleIds(List<long> roleIds);

        List<SysMenu> GetSubMenusByParentCode(string id);
    }
}
