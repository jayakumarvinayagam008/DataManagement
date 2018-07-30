using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDataProcess.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDataProcess.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountModel accountModel)
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}