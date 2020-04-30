using System.Collections.Generic;

namespace Doublelives.Api.Models.Dept
{
    public class DeptViewModel
    {
        public List<DeptViewModel> Children { get; set; }

        public string CreateBy { get; set; }

        public string CreateTime { get; set; }

        public string Fullname { get; set; }

        public string Id { get; set; }

        public string ModifyBy { get; set; }

        public string ModifyTime { get; set; }

        public long Num { get; set; }

        public string Pid { get; set; }

        public string Pids { get; set; }

        public string Simplename { get; set; }

        public string Tips { get; set; }

        public string Version { get; set; }
    }
}