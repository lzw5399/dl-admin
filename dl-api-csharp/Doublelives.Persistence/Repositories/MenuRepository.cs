using Doublelives.Domain.Sys;
using Doublelives.Shared.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Doublelives.Persistence.Repositories
{
    public class MenuRepository : Repository<SysMenu>, IMenuRepository
    {
        private readonly DlAdminDbContext _context;

        public MenuRepository(DlAdminDbContext context) : base(context)
        {
            _context = context;
        }

        public List<string> GetPermissionsByRoleIds(List<int> roleIds, bool activeOnly = true)
        {
            List<string> permissions;
            if (activeOnly)
            {
                permissions = _context.Set<SysRelation>()
                   .Join(
                   _context.Set<SysMenu>().Where(
                       it => (it.Status == (int)MenuStatus.Active) && roleIds.Contains(it.Id)),
                   relation => relation.Menuid.Value,
                   menu => menu.Id,
                   (relation, menu) => menu.Url)
                   .ToList();
            }

            permissions = _context.Set<SysRelation>()
               .Join(
               _context.Set<SysMenu>().Where(it => roleIds.Contains(it.Id)),
               relation => relation.Menuid.Value,
               menu => menu.Id,
               (relation, menu) => menu.Url)
               .ToList();

            var x = permissions.Distinct().ToList();

            return x;
        }
    }
}
