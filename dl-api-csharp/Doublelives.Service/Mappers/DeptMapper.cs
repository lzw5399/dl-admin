using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Extensions;
using System.Collections.Generic;

namespace Doublelives.Service.Mappers
{
    public static class DeptMapper
    {
        public static DeptDto ToDeptDto(SysDept sysDept)
        {
            var dto = new DeptDto
            {
                Fullname = sysDept.Fullname,
                Simplename = sysDept.Simplename,
                CreateBy = sysDept.CreateBy?.ToString() ?? string.Empty,
                CreateTime = sysDept.CreateTime?.ToString() ?? string.Empty,
                Id = sysDept.Id.ToString(),
                ModifyBy = sysDept.ModifyBy?.ToString() ?? string.Empty,
                ModifyTime = sysDept.ModifyTime?.ToString() ?? string.Empty,
                Num = sysDept.Num ?? 1,
                Pid = sysDept.Pid.Value().ToString(),
                Pids = sysDept.Pids,
                Tips = sysDept.Tips,
                Version = sysDept.Version?.ToString() ?? "1",
                Children = new List<DeptDto>()
            };

            return dto;
        }
    }
}
