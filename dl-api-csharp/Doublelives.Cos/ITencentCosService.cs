using Doublelives.Domain.Pictures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Cos
{
    public interface ITencentCosService
    {
        IEnumerable<Picture> GetDoublelivesBucketPictures();
    }
}
