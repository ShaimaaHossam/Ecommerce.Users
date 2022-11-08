using Ecommerce.Users.Shared;
using Ecommerce.Users.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Users.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterAsync(RegisterViewModel registerViewModel);
        Task<UserManagerResponse> LoginAsync(LoginViewModel loginViewModel);

    }
}
