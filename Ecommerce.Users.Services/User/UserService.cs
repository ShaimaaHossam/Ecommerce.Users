using Ecommerce.Users.Shared;
using Ecommerce.Users.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.Services
{
    public class UserService:IUserService
    {
        private UserManager<IdentityUser> userManager;
        public UserService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<UserManagerResponse> RegisterAsync(RegisterViewModel user)
        {
            if(user == null)
            {
                throw new NullReferenceException("User is null");
            }
            if(user.ConfirmPassword != user.Password)
            {
                return new UserManagerResponse()
                {
                    isSuccess = false,
                    Message = "Passwords do not match"
                };
            }
            var identityUser = new IdentityUser()
            {
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber
            };
            var result = await userManager.CreateAsync(identityUser, user.Password);
            if (result.Succeeded)
            {
                return new UserManagerResponse()
                {
                    Message = "User Created Successfuly",
                    isSuccess = true,
                };
            }
            return new UserManagerResponse()
            {
                Message = "Error registering user",
                isSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
}
