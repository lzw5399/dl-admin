using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Infrastructure.Extensions
{
    public static class CoreExtensions
    {
        public static long Value(this long? v) => v.HasValue ? v.Value : -1;

        public static int Value(this int? v) => v.HasValue ? v.Value : -1;

        public static DateTime Value(this DateTime? v) => v.HasValue ? v.Value : DateTime.MinValue;
    }
}
