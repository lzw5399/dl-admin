using System;
using System.Collections.Generic;
using System.Linq;

namespace Doublelives.Shared.Models
{
    public class PagedModel<T>
    {
        public PagedModel()
        {
            Data = new T[0];
        }

        public IReadOnlyList<T> Data { get; set; }

        /// <summary>
        /// 当前第几页
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// 每页多少条数据
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总共的数据数量
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总共有多少页
        /// </summary>
        public int PageCount => (int)Math.Ceiling((decimal)TotalCount / PageSize);

        /// <summary>
        /// 当前页的数据数量
        /// </summary>
        public int Count => Data?.Count() ?? 0;

        /// <summary>
        /// 按什么排序的
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 是否正序
        /// </summary>
        public bool Ascending { get; set; }
    }
}
