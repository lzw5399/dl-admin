using System;

namespace Doublelives.Domain.Sys.Dto
{
    public class RoleProfileDto
    {
        public int Id { get; set; }

        public int? Deptid { get; set; }

        public string DeptName { get; set; }

        public string Name { get; set; }

        public int? Num { get; set; }

        /// <summary>
        /// 上级角色的id
        /// </summary>
        public int? Pid { get; set; }

        /// <summary>
        /// 上级角色的Name
        /// </summary>
        public string PName { get; set; }

        public string Tips { get; set; }

        public int? Version { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        public int? ModifyBy { get; set; }
    }
}