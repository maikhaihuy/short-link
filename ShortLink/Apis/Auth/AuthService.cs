using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ShortLink.Base;
using ShortLink.Common.Helpers;
using ShortLink.EntityFramework;
using ShortLink.EntityFramework.Entities;
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
            // validate
            Account account = DbContext.Accounts.Where(a => a.Username == loginParam.LoginName).FirstOrDefault();
            if (account is null)
            {
                throw new UnauthorizedAccessException("Username and Password ...");
            }

            if (!CryptoHelpers.VerifyPassword(loginParam.Password, account.Password))
            {
                throw new UnauthorizedAccessException();
            }

            // prepare

            // execute

            // transfer

            return null;
        }

        public async Task<AccountModel> Register(RegisterParam registerParam)
        {
            // validate
            Account account = DbContext.Accounts.Where(a => a.Username == registerParam.LoginName).FirstOrDefault();
            if (account is not null)
            {
                throw new ValidationException($"Username was exist.");
            }

            // prepare
            account = _mapper.Map<Account>(registerParam);
            account.Password = CryptoHelpers.PasswordHash(registerParam.Password);

            // execute
            var accountEntry = DbContext.Accounts.Add(account);
            await DbContext.SaveChangesAsync();

            // transfer
            var accountModel = _mapper.Map<AccountModel>(accountEntry.Entity);
            return accountModel;
        }
    }
}