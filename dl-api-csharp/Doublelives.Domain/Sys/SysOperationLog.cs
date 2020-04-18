using Doublelives.Domain.Infrastructure;
using System;

namespace Doublelives.Domain.Sys
{
    public class SysOperationLog : EntityBase
    {
        public SysOperationLog()
        {
            CreateTime = DateTime.Now;
        }

        public string Classname { get; set; }

        public DateTime? CreateTime { get; set; }

        public string Logname { get; set; }

        public string Logtype { get; set; }

        public string Message { get; set; }

        public string Method { get; set; }

        public string Succeed { get; set; }

        public long? Userid { get; set; }
    }
}
