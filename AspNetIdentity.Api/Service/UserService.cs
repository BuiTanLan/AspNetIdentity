using System.Linq;
using System.Threading.Tasks;
using AspNetIdentity.Api.Interfaces;
using AspNetIdentity.Shared;
using Microsoft.AspNetCore.Identity;

namespace AspNetIdentity.Api.Service
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserService(UserManager<IdentityUser> userManager)
        {
           _userManager = userManager;

        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model)
        {
            if(model == null) throw new System.NotImplementedException();
            if(model.ConfirmPassword != model.Password)
            {
                return new UserManagerResponse
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false
                };
            }

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result =  await _userManager.CreateAsync(identityUser, model.Password);

            if(result.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "User created successfully",
                    IsSuccess = true,
                };
            }
            return new UserManagerResponse
            {
                Message ="User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }
    }
}