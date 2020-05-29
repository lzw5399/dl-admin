using System.Threading.Tasks;
using Doublelives.Domain.Pictures;
using Doublelives.Domain.Sys;
using Doublelives.Domain.Users;
using Doublelives.Persistence.Repositories;

namespace Doublelives.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DlAdminDbContext _albumDbContext;

        public UnitOfWork(DlAdminDbContext albumDbContext)
        {
            _albumDbContext = albumDbContext;
            PictureRepository = new Repository<Picture>(albumDbContext);
            UserRepository = new Repository<SysUser>(albumDbContext);
            RoleRepository = new Repository<SysRole>(albumDbContext);
            DeptRepository = new Repository<SysDept>(albumDbContext);
            NoticeRepository = new Repository<SysNotice>(albumDbContext);
            MenuRepository = new MenuRepository(albumDbContext);
            TaskLogRepository = new Repository<SysTaskLog>(albumDbContext);
            CfgRepository = new Repository<SysCfg>(albumDbContext);
            DictRepository = new Repository<SysDict>(albumDbContext);
        }

        public IRepository<Picture> PictureRepository { get; private set; }

        public IRepository<SysUser> UserRepository { get; private set; }

        public IRepository<SysRole> RoleRepository { get; private set; }

        public IRepository<SysDept> DeptRepository { get; private set; }

        public IRepository<SysNotice> NoticeRepository { get; private set; }

        public IRepository<SysTaskLog> TaskLogRepository { get; private set; }

        public IRepository<SysDict> DictRepository { get; private set; }

        public IRepository<SysCfg> CfgRepository { get; private set; }

        public IMenuRepository MenuRepository { get; private set; }

        public void Commit()
        {
            _albumDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _albumDbContext.SaveChangesAsync();
        }
    }
}