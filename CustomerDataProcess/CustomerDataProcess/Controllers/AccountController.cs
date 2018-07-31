using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UserAccount.Queries;
using CustomerDataProcess.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDataProcess.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserValidation _userValidation;
        public AccountController(IUserValidation userValidation)
        {
            _userValidation = userValidation;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountModel accountModel)
        {
            if(accountModel.IsLoginRequest || true)
            {
                var userValidation = _userValidation.Validate(new UserLogin
                {
                    Password = accountModel.UserLogin.Password,
                    UserName = accountModel.UserLogin.UserName
                });
                if(userValidation.IsValidUser)
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}