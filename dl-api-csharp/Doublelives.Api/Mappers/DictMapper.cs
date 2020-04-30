using Doublelives.Api.Models.Dicts.Requests;
using Doublelives.Domain.Sys.Dto;

namespace Doublelives.Api.Mappers
{
    public class DictMapper
    {
        public static DictSearchDto ToDictSearchDto(DictListSearchRequest request)
        {
            var dto = new DictSearchDto
            {
                Limit = request.Limit == 0 ? 20 : request.Limit,
                Page = request.Page == 0 ? 1 : request.Page,
                Name = request.Name
            };

            return dto;
        }
    }
}