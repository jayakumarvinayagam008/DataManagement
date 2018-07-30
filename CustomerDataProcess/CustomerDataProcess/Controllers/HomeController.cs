using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustomerDataProcess.Models;

namespace CustomerDataProcess.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult BusinessToBusiness()
        {
            return View();
        }

        public IActionResult BusinessToCustomers()
        {
            return View();
        }

        public IActionResult CustomerData()
        {
            return View();
        }

        public IActionResult UploadUserData()
        {
            return View();
        }
       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
