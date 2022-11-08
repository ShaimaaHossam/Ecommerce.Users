using Ecommerce.Users.Shared;
using Ecommerce.Users.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.Services
{
    public class UserService:IUserService
    {
        private UserManager<IdentityUser> userManager;
        private IConfiguration configuration;
        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
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
        public async Task<UserManagerResponse> LoginAsync(LoginViewModel loginViewModel)
        {
            var user = await userManager.FindByEmailAsync(loginViewModel.Email);
            if(user == null)
            {
                return new UserManagerResponse()
                {
                    Message = "This Email Address doesn't exist.",
                    isSuccess = false
                };
            }
            var result = await userManager.CheckPasswordAsync(user, loginViewModel.Password);
            if (!result)
            {
                return new UserManagerResponse()
                {
                    Message = "Incorrect Password",
                    isSuccess = false
                };
            }
            var claims = new[]
            {
                new Claim("Email", loginViewModel.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"]));
            var token = new JwtSecurityToken(
                issuer: configuration["AuthSettings:Issuer"],
                audience: configuration["AuthSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                ) ;

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse()
            {
                Message = tokenAsString,
                isSuccess = true,
                ExpiredDate = token.ValidTo
            };

        }

    }
}
