using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Infrastructure.Extensions
{
    public static class CoreExtensions
    {
        public static long Value(this long? v)
        {
            return v ?? -1;
        }

        public static int Value(this int? v)
        {
            return v ?? -1;
        }

        public static DateTime Value(this DateTime? v)
        {
            return v ?? DateTime.MinValue;
        }
    }
}