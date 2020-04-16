using Doublelives.Domain.Pictures;
using System.Collections.Generic;

namespace Doublelives.Cos
{
    public interface ITencentCosService
    {
        IEnumerable<Picture> GetDoublelivesBucketPictures();
    }
}
