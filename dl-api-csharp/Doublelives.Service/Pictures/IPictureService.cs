using System;
using System.Collections.Generic;
using System.Text;
using Doublelives.Domain.Pictures;
using Microsoft.AspNetCore.Http;

namespace Doublelives.Service.Pictures
{
    public interface IPictureService
    {
        IEnumerable<Picture> GetAll();

        void Upload(string userId, List<IFormFile> files);
    }
}
