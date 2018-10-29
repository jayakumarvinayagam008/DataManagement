using Application.Common;

namespace Application.BusinessToCustomers.Queries
{
    public class BusinessToCustomerFilter : SearchRequest
    {
        public string[] Areas { get; set; }
        public string[] Roles { get; set; }
        public int[] Age { get; set; }
        public string[] Salaries { get; set; }
        public string[] Experience { get; set; }
    }
}