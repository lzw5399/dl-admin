using Doublelives.Domain.Pictures;
using System.Collections.Generic;

namespace Doublelives.Service.TencentCos
{
    public interface ITencentCosService
    {
        IEnumerable<Picture> GetDoublelivesBucketPictures();
    }
}
