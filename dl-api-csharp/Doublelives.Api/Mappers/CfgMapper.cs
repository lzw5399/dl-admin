using Doublelives.Api.Models.Cfgs.Requests;
using Doublelives.Domain.Sys.Dto;

namespace Doublelives.Api.Mappers
{
    public class CfgMapper
    {
        public static CfgSearchDto ToCfgSearchDto(CfgListSearchRequest request)
        {
            var dto = new CfgSearchDto
            {
                CfgName = request.CfgName,
                CfgValue = request.CfgValue,
                Limit = request.Limit == 0 ? 20 : request.Limit,
                Page = request.Page == 0 ? 1 : request.Page
            };

            return dto;
        }
    }
}
