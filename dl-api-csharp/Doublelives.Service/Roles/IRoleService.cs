using Doublelives.Domain.Sys;
using System.Collections.Generic;

namespace Doublelives.Service.Roles
{
    public interface IRoleService
    {
        /// <summary>
        /// 根据获取单个role
        /// </summary>
        SysRole GetById(int id);

        /// <summary>
        /// 根据ids获取role列表
        /// </summary>
        List<SysRole> GetListByIds(List<int> ids);

        /// <summary>
        /// 获取所有的role
        /// </summary>
        List<SysRole> List();
    }
}
