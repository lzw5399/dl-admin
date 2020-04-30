namespace Doublelives.Api.Models.Roles.Requests
{
    public class RoleListSearchRequest : BasePagedListRequest
    {
        public string Name { get; set; }
    }
}