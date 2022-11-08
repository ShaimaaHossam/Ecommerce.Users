﻿using Ecommerce.Users.Services;
using Ecommerce.Users.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Users.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public ActionResult Hello()
        {
            return Ok("Hello");
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await userService.RegisterAsync(model);
                if (result.isSuccess)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            return BadRequest("Information is missing");
        }
        
    }
}
