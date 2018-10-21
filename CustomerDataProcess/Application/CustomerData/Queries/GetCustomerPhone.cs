using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.CustomerData.Queries
{
    public class GetCustomerPhone : IGetCustomerPhone
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetCustomerPhone(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public List<string> Get()
        {
            var numbers = _customerDataManagementContext.CustomerDataManagement.Select(x => x.Numbers).ToList();
            return numbers;
        }
    }
}