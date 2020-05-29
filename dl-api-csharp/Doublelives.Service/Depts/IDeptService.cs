using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doublelives.Service.Depts
{
    public interface IDeptService
    {
        Task<List<DeptDto>> List();

        Task<SysDept> GetById(int id);
    }
}