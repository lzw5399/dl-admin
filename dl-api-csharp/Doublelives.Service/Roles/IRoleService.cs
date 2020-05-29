using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doublelives.Service.Roles
{
    public interface IRoleService
    {
        /// <summary>
        /// 根据获取单个role
        /// </summary>
        Task<SysRole> GetById(int id);

        /// <summary>
        /// 根据ids获取role列表
        /// </summary>
        Task<List<SysRole>> GetListByIds(List<int> ids);

        /// <summary>
        /// 获取分页的role
        /// </summary>
        Task<PagedModel<RoleProfileDto>> GetPagedList(RoleSearchDto criteria);
    }
}