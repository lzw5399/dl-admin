namespace Doublelives.Domain.Sys.Dto
{
    public class CfgSearchDto : BasePagedListDto
    {
        public string CfgName { get; set; }

        public string CfgValue { get; set; }
    }
}