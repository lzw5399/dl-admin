using Doublelives.Domain.Sys.Dto;
using Doublelives.Shared.Models;
using System.Threading.Tasks;

namespace Doublelives.Service.Cfgs
{
    public interface ICfgService
    {
        Task<PagedModel<CfgDto>> GetPagedList(CfgSearchDto criteria);
    }
}
