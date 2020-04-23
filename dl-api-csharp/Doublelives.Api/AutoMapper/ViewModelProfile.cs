using AutoMapper;
using Doublelives.Api.Models.Account;
using Doublelives.Api.Models.Album;
using Doublelives.Api.Models.Dept;
using Doublelives.Api.Models.Menu;
using Doublelives.Api.Models.Notice;
using Doublelives.Api.Models.Users;
using Doublelives.Domain.Pictures;
using Doublelives.Domain.Sys.Dto;
using Doublelives.Domain.Users;
using Doublelives.Domain.Users.Dto;

namespace Doublelives.Api.AutoMapper
{
    public class ViewModelProfile : Profile
    {
        public ViewModelProfile()
        {
            CreateMap<Picture, PicturesViewModel>();
            
            // user related
            CreateMap<User, UserViewModel>();
            CreateMap<CurrentUserDto, UserViewModel>();


            CreateMap<AccountProfileDto, AccountProfileViewModel>();
            CreateMap<AccountInfoDto, AccountInfoViewModel>();

            // menu router
            CreateMap<RouterDto, RouterViewModel>();
            CreateMap<MetaDto, MetaViewModel>();

            // notice
            CreateMap<NoticeDto, NoticeViewModel>();

            // dept
            CreateMap<DeptDto, DeptViewModel>();
        }
    }
}
