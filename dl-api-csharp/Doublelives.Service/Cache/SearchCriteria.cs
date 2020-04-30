using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Service.Cache
{
    public class SearchCriteria
    {
        /// <summary>
        /// 模糊搜索字段名
        /// </summary>
        public string[] SearchFields { get; set; }

        public string Keyword { get; set; }

        public bool FuzzySearch => !string.IsNullOrEmpty(Keyword);

        /// <summary>
        /// 偏移量
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// 每页的数量
        /// </summary>
        public int Count { get; set; }
    }
}
