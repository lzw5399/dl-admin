using AutoMapper;
using Doublelives.Api.Models.Account;
using Doublelives.Api.Models.Album;
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
        }
    }
}
