using Doublelives.Domain.Sys.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Service.Menus
{
    public interface IMenuService
    {
        List<RouterDto> GetMenuRouterList(long userid);
    }
}
