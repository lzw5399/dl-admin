using System;
using System.Collections.Generic;

namespace Doublelives.Migrations.DbFirstProcess
{
    public class Message : AuditableEntityBase
    {
        public string Content { get; set; }

        public string Receiver { get; set; }

        public string State { get; set; }

        public string TplCode { get; set; }

        public string Type { get; set; }
    }
}
