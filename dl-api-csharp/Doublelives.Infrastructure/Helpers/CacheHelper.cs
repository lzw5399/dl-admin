namespace Doublelives.Infrastructure.Helpers
{
    public static class CacheHelper
    {
        public static string ToCacheKey(string prefix, params object[] parameters)
        {
            return $"{prefix}_{string.Join('_', parameters)}";
        }
    }
}