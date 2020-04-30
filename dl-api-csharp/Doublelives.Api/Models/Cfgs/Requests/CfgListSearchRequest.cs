namespace Doublelives.Api.Models.Cfgs.Requests
{
    public class CfgListSearchRequest : BasePagedListRequest
    {
        public string CfgName { get; set; }

        public string CfgValue { get; set; }
    }
}