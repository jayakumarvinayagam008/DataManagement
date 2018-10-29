namespace Application.UserAccount.Queries
{
    public interface IUserValidation
    {
        ValidationResponse Validate(UserLogin userLogin);
    }
}