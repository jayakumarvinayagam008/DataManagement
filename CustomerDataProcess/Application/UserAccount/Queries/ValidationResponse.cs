namespace Application.UserAccount.Queries
{
    public class ValidationResponse
    {
        public bool IsValidUser { get; set; }
        public string AccountName { get; set; }
        public string TokenId { get; set; }
    }
}