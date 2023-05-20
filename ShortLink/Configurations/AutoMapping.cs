using System.Data;
using AutoMapper;
using ShortLink.Apis.Auth;
using ShortLink.Common.Helpers;
using ShortLink.EntityFramework.Entities;
using ShortLink.Models;

namespace ShortLink.Configurations
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UrlModel, Url>().ReverseMap();

            AccountMappingProfile();
        }

        private void AccountMappingProfile()
        {
            CreateMap<AccountModel, Account>().ReverseMap();

            CreateMap<RegisterParam, Account>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.LoginName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => CryptoHelpers.PasswordHash(src.Password)));

            CreateMap<LoginParam, Account>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.LoginName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}