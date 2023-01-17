using System.Threading.Tasks;
using ShortLink.Models;

namespace ShortLink.Apis.Auth
{
    public interface IAuthService
    {
        Task<AccountModel> Login(LoginParam loginParam);
        Task<AccountModel> Register(RegisterParam registerParam);
    }
}