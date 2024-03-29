﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaticK9.F.Models;
using StaticK9.F.Repositories;

namespace StaticK9.F.MainUI.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly IUserRepository userRepository;

        public AccountController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login(string returnURL="/")
        {
            return View(new LoginModel { ReturnUrl = returnURL});
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = userRepository.GetByUsernameAndPassword(model.Username, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.Name.ToString()),
                    new Claim(ClaimTypes.Role,user.Role),
                    new Claim("FavoriteColor", user.FavoriteColor),

             };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principle = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle, new AuthenticationProperties { IsPersistent = model.RememberLogin });
            return LocalRedirect(model.ReturnUrl);
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
