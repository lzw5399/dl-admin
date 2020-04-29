using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Persistence;
using Doublelives.Shared.Models;

namespace Doublelives.Service.Dicts
{
    public class DictService : IDictService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DictService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PagedModel<DictProfileDto> GetPagedList(DictSearchDto criteria)
        {
            throw new System.NotImplementedException();
        }
    }
}
