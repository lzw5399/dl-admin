using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doublelives.Api.Infrastructure;
using Doublelives.Api.Models.Album;
using Doublelives.Domain.Pictures;
using Doublelives.Service.Pictures;
using Doublelives.Service.WorkContextAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    public class AlbumController : AuthControllerBase
    {
        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;

        public AlbumController(
            IWorkContextAccessor workContextAccessor,
            IPictureService pictureService,
            IMapper mapper)
            : base(workContextAccessor)
        {
            _pictureService = pictureService;
            _mapper = mapper;
        }

        /// <summary>获取所有的图片链接</summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var pictures = _pictureService.GetAll();

            var response = _mapper.Map<IEnumerable<PicturesViewModel>>(pictures);

            return Ok(response);
        }

        /// <summary>通过etag获取图片</summary>
        /// <param name="id">图片的etag</param>
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok();
        }

        /// <summary>上传图片(一个或多个)</summary>
        /// <param name="files">文件</param>
        [HttpPost]
        public IActionResult UploadPicture(List<IFormFile> files)
        {
            _pictureService.Upload(WorkContext.CurrentUser.Id.ToString(), files);

            return Ok();
        }

        /// <summary>通过etag删除图片</summary>
        /// <param name="id">etag</param>
        [HttpDelete("{id}")]
        public IActionResult DeletePicture(string id)
        {
            return Ok();
        }

        /// <summary>用于引发除以0的异常，测试专用</summary>
        [AllowAnonymous]
        [HttpGet("divideByZero")]
        public IActionResult DivideByZero()
        {
            int x = 1, y = 0;
            var z = x / y;

            return Ok(z);
        }
    }
}