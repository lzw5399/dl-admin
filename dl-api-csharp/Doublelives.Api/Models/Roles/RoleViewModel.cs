using System;

namespace Doublelives.Api.Models.Roles
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        public string Deptid { get; set; }

        public string Name { get; set; }

        public int Num { get; set; }

        public string Pid { get; set; }

        public string PName { get; set; }

        public string Tips { get; set; }

        public int Version { get; set; }

        public string DeptName { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }
    }
}
