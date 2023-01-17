using System.Data;
using AutoMapper;
using ShortLink.EntityFramework.Entities;
using ShortLink.Models;

namespace ShortLink.Configurations
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<AccountModel, Account>().ReverseMap();
            CreateMap<UrlModel, Url>().ReverseMap();
        }
    }
}