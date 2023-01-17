using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ShortLink.Base;
using ShortLink.EntityFramework;
using ShortLink.Models;

namespace ShortLink.Apis.Auth
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IMapper _mapper;
        public AuthService(IMapper mapper, ShortLinkDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
            _mapper = mapper;
        }

        public async Task<AccountModel> Login(LoginParam loginParam)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountModel> Register(RegisterParam registerParam)
        {
            throw new NotImplementedException();
        }
    }
}