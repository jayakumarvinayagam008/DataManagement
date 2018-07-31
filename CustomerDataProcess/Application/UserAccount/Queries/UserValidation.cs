using System;
namespace Application.UserAccount.Queries
{
    public class UserValidation:IUserValidation
    {
        
        public ValidationResponse Validate(UserLogin userLogin)
        {
            if (userLogin.UserName.ToLower().Equals("jaya") && userLogin.Password.Equals("12345"))
            {
                return new ValidationResponse { 
                    IsValidUser = true,
                    AccountName = "Jayakumar Vinayagam",
                    TokenId = "12123fgevdffggfgfgg"
                };
            }
              
            return new ValidationResponse{
                IsValidUser = false
            };
        }
    }
}
