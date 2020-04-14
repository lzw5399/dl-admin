using Doublelives.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Domain.Pictures
{
    public class Picture : AuditableEntityBase
    {
        public Picture()
        {
            Uploader = "unknown";
        }

        public string ETag { get; set; }

        public DateTime LastModified { get; set; }

        public string Uploader { get; set; }

        /// <summary>
        /// 文件大小，单位是byte
        /// </summary>
        public long Size { get; set; }

        public string Url { get; set; }
    }
}
