using COSXML;
using System;
using Microsoft.Extensions.Options;
using COSXML.Utils;
using COSXML.Model.Bucket;
using Doublelives.Shared.ConfigModels;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using Doublelives.Domain.Pictures;
using COSXML.Auth;
using System.Drawing;

namespace Doublelives.Service.TencentCos
{
    public class TencentCosService : ITencentCosService
    {
        private readonly CosXml _cosXml;
        private readonly TencentCosOptions _cosConfig;

        public TencentCosService(IOptions<TencentCosOptions> options)
        {
            _cosConfig = options.Value;
            _cosXml = InitCosXml();
        }

        public IEnumerable<Picture> GetDoublelivesBucketPictures()
        {
            var result = GetPicturesByBucket(_cosConfig.Bucket);

            return result;
        }

        public void Upload(List<Image> images)
        {
            // PutObjectRequest request = new PutObjectRequest();
        }

        private IEnumerable<Picture> GetPicturesByBucket(string bucket)
        {
            var request = new GetBucketRequest(bucket);
            //设置签名有效时长
            request.SetSign(TimeUtils.GetCurrentTime(TimeUnit.SECONDS), _cosConfig.DurationSecond);
            GetBucketResult response = _cosXml.GetBucket(request);

            var result = response.listBucket.contentsList
                    .Select(it =>
                    {
                        var picture = new Picture
                        {
                            Url = $"{_cosConfig.BaseUrl}/{HttpUtility.HtmlEncode(it.key)}",
                            Size = it.size,
                            ETag = it.eTag
                        };
                        DateTime.TryParse(it.lastModified, out var time);
                        picture.LastModified = time;

                        return picture;
                    })
                    .OrderByDescending(it => it.LastModified);

            return result;
        }

        private CosXml InitCosXml()
        {
            var cosXmlConfig = new CosXmlConfig.Builder()
                .IsHttps(false)
                .SetAppid(_cosConfig.AppId)
                .SetRegion(_cosConfig.Region)
                .SetDebugLog(true)
                .Build();
            var cosCredentialProvider = new DefaultQCloudCredentialProvider(
                _cosConfig.SecretId,
                _cosConfig.SecretKey,
                _cosConfig.DurationSecond);

            return new CosXmlServer(cosXmlConfig, cosCredentialProvider);
        }
    }
}
