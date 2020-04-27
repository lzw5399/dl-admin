namespace Doublelives.Infrastructure.Helpers
{
    public static class CacheHelper
    {
        public static string ToCacheKey(string prefix, params object[] parameters) => $"{prefix}_{string.Join('_', parameters)}";
    }
}
