﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WishList.Models;
using WishList.Models.AccountViewModels;

namespace WishList.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet,AllowAnonymous]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost,AllowAnonymous]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            { 
                return View(registerViewModel);
            }
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.Email = registerViewModel.Email;
            applicationUser.PasswordHash = registerViewModel.Password;
            var result=_userManager.CreateAsync(applicationUser);
            if (result.Result.Succeeded)
            {
                return View("Register");
            }
            return RedirectToAction("HomeController.Index");
         }
    }
}
