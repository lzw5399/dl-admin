using Doublelives.Domain.Sys;
using Doublelives.Shared.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Doublelives.Persistence.Repositories
{
    public class MenuRepository : Repository<SysMenu>, IMenuRepository
    {
        private readonly DlAdminDbContext _context;

        public MenuRepository(DlAdminDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<SysMenu>> GetTopLevelMenusByRoleIds(List<int> roleIds)
        {
            var menus = await _context.Set<SysRelation>()
                .Where(it => roleIds.Contains(it.Roleid))
                .Join(
                    _context.Set<SysMenu>().Where(
                        menu => menu.Status == MenuStatus.Active && menu.Ismenu &&
                                menu.Levels == (int) MenuLevel.Top),
                    relation => relation.Menuid,
                    menu => menu.Id,
                    (relation, menu) => menu)
                .ToListAsync();

            return menus;
        }

        public async Task<List<SysMenu>> GetSubMenusByParentCode(string pcode)
        {
            var menus =
                await _context
                    .Set<SysMenu>()
                    .Where(menu => menu.Status == MenuStatus.Active &&
                                   menu.Ismenu &&
                                   menu.Pcode == pcode)
                    .ToListAsync();

            return menus;
        }

        public async Task<List<string>> GetPermissionsByRoleIds(List<int> roleIds, bool activeOnly = true)
        {
            List<string> permissions;
            if (activeOnly)
                permissions = await _context.Set<SysRelation>()
                    .Where(it => roleIds.Contains(it.Roleid))
                    .Join(
                        _context.Set<SysMenu>().Where(menu => menu.Status == MenuStatus.Active),
                        relation => relation.Menuid,
                        menu => menu.Id,
                        (relation, menu) => menu.Url)
                    .ToListAsync();
            //permissions = (from r in _context.Set<SysRelation>()
            //               join m in _context.Set<SysMenu>() on r.Menuid equals m.Id
            //               where roleIds.Contains(r.Roleid) && m.Status == MenuStatus.Active
            //               select m.Url).ToList();
            else
                permissions = await _context.Set<SysRelation>()
                    .Where(it => roleIds.Contains(it.Roleid))
                    .Join(
                        _context.Set<SysMenu>(),
                        relation => relation.Menuid,
                        menu => menu.Id,
                        (relation, menu) => menu.Url)
                    .ToListAsync();

            return permissions.Where(it => !string.IsNullOrWhiteSpace(it)).Distinct().ToList();
        }
    }
}