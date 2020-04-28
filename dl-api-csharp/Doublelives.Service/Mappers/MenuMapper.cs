using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Doublelives.Service.Mappers
{
    public static class MenuMapper
    {
        public static RouterDto ToRouterDto(SysMenu topMenu, List<SysMenu> subMenus)
        {
            var dto = new RouterDto
            {
                Id = topMenu.Id,
                ParentId = 0,
                Component = !string.IsNullOrEmpty(topMenu.Component) ? topMenu.Component : string.Empty,
                Hidden = topMenu.Hidden,
                Name = topMenu.Name,
                Num = topMenu.Num,
                Path = !string.IsNullOrEmpty(topMenu.Url) ? topMenu.Url : string.Empty,
                Meta = new MetaDto
                {
                    Icon = topMenu.Icon,
                    Title = topMenu.Code
                },
                Children = subMenus
                    .Select(it => new RouterDto
                    {
                        Children = new List<RouterDto>(),
                        Component = it.Component,
                        Hidden = it.Hidden,
                        Id = it.Id,
                        Meta = new MetaDto
                        {
                            Icon = it.Icon,
                            Title = it.Code
                        },
                        Name = it.Name,
                        Num = it.Num,
                        ParentId = topMenu.Id,
                        Path = it.Url
                    })
                    .OrderBy(it => it.Num)
                    .ToList()
            };

            return dto;
        }
    }
}
