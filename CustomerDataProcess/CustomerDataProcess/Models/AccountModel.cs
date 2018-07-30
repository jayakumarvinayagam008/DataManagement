using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDataProcess.Models
{
    public class AccountModel
    {
        public UserRegisterModel UserRegister { get; set; }
        public UserLoginModel UserLogin { get; set; }
        public bool IsLoginRequest { get; set; }
    }
}
