using System.Threading.Tasks;
using AspNetIdentity.Shared;

namespace AspNetIdentity.Api.Interfaces
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model);
    }
}