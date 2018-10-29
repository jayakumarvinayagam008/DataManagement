using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToCustomers.Queries
{
    public class GetBusinessToCustomerPhone : IGetBusinessToCustomerPhone
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessToCustomerPhone(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public List<string> Get()
        {
            var numbers = _customerDataManagementContext.BusinessToCustomer.Select(x => x.MobileNew).ToList();
            return numbers;
        }
    }
}