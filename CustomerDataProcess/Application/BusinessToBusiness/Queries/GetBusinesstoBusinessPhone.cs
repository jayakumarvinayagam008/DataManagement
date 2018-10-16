using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinesstoBusinessPhone : IGetBusinesstoBusinessPhone
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        public GetBusinesstoBusinessPhone(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }
        public List<string> Get()
        {
            var numbers = _customerDataManagementContext.BusinessToBusiness.Select(x => x.MobileNew).ToList();
            return numbers;
        }
    }
}
