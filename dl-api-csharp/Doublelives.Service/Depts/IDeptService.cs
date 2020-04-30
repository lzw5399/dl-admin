using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using System.Collections.Generic;

namespace Doublelives.Service.Depts
{
    public interface IDeptService
    {
        List<DeptDto> List();

        SysDept GetById(int id);
    }
}