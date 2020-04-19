﻿using Doublelives.Domain.Sys;
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
                    .Where(it => roleIds.Contains(it.Roleid))
                    .Join(
                    _context.Set<SysMenu>().Where(
                        menu => (menu.Status == (int)MenuStatus.Active)),
                    relation => relation.Menuid,
                    menu => menu.Id,
                    (relation, menu) => menu.Url)
                    .ToList();
                //var qw = from r in _context.Set<SysRelation>()
                //         join m in _context.Set<SysMenu>() on r.Menuid equals m.Id
                //         where roleIds.Contains(r.Roleid) && m.Status == (int)MenuStatus.Active
                //         select m.Url;
                //var rr = qw.ToList();
            }
            else
            {
                permissions = _context.Set<SysRelation>()
                    .Where(it => roleIds.Contains(it.Roleid))
                    .Join(
                    _context.Set<SysMenu>(),
                    relation => relation.Menuid,
                    menu => menu.Id,
                    (relation, menu) => menu.Url)
                    .ToList();
            }

            return permissions.Distinct().ToList();
        }
    }
}