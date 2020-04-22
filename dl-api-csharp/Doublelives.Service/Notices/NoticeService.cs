using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Cache;
using Doublelives.Infrastructure.Helpers;
using Doublelives.Shared.Constants;
using System.Collections.Generic;

namespace Doublelives.Service.Notices
{
    public class NoticeService : INoticeService
    {
        private readonly ICacheManager _cacheManager;

        public NoticeService(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public List<NoticeDto> List(string title)
        {
            var cacheKey = CacheHelper.ToCacheKey(CacheKeyPrefix.NOTICE_CACHE_PREFIX, title);
            var result = _cacheManager.GetOrCreateAsync(cacheKey, async entry =>
            {
                return new List<NoticeDto>();
            }).Result;

            return result;
        }
    }
}
