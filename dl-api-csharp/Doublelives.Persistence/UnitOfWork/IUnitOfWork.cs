using Doublelives.Domain.Pictures;
using Doublelives.Domain.Sys;
using Doublelives.Domain.Users;
using Doublelives.Persistence.Repositories;

namespace Doublelives.Persistence
{
    public interface IUnitOfWork
    {
        IRepository<Picture> PictureRepository { get; }

        IRepository<SysUser> UserRepository { get; }

        IRepository<SysRole> RoleRepository { get; }

        IRepository<SysDept> DeptRepository { get; }

        IRepository<SysNotice> NoticeRepository { get; }

        IRepository<SysTaskLog> TaskLogRepository { get; }

        IRepository<SysDict> DictRepository { get; }

        IRepository<SysCfg> CfgRepository { get; }

        IMenuRepository MenuRepository { get; }

        void Commit();
    }
}