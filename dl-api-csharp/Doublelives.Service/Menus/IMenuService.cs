using Doublelives.Domain.Sys.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Doublelives.Service.Menus
{
    public interface IMenuService
    {
        Task<List<RouterDto>> GetMenuRouterList(int userid);
    }
}