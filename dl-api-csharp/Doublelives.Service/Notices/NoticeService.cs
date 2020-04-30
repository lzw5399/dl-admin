using Doublelives.Domain.Sys;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Infrastructure.Helpers;
using Doublelives.Persistence;
using Doublelives.Service.Cache;
using Doublelives.Service.Mappers;
using Doublelives.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Doublelives.Service.Notices
{
    public class NoticeService : INoticeService
    {
        private readonly ICacheManager _cacheManager;
        private readonly IUnitOfWork _unitOfWork;

        public NoticeService(ICacheManager cacheManager, IUnitOfWork unitOfWork)
        {
            _cacheManager = cacheManager;
            _unitOfWork = unitOfWork;
        }

        public List<NoticeDto> List(string title)
        {
            var cacheKey = CacheHelper.ToCacheKey(CacheKeyPrefix.NOTICE_CACHE_PREFIX, title);
            var result = _cacheManager.GetOrCreateAsync(cacheKey, async entry =>
            {
                List<SysNotice> notices;
                if (string.IsNullOrEmpty(title))
                {
                    notices = await _unitOfWork.NoticeRepository
                    .GetAsQueryable()
                    .ToListAsync();
                }
                else
                {
                    notices = await _unitOfWork.NoticeRepository
                    .GetAsQueryable()
                    .Where(it => it.Title == title)
                    .ToListAsync();
                }

                return notices.Select(it => NoticeMapper.ToNoticeDto(it)).ToList();
            }).Result;

            return result;
        }
    }
}
