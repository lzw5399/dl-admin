using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Shared.ConfigModels
{
    public class TencentCosOptions
    {
        public string AppId { get; set; }

        public string SecretId { get; set; }

        public string SecretKey { get; set; }

        public string Bucket { get; set; }

        public string Region { get; set; }

        // secretKey 有效时长,单位为 秒
        public int DurationSecond { get; set; }

        public string BaseUrl { get; set; }
    }
}