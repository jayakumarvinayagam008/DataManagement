using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Collections.Generic;
using System.Linq;

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
              var numbers = _customerDataManagementContext.BusinessToBusiness.Select(x => x.PhoneNew.Trim()).Distinct().ToList();
            return numbers;
        }
    }
    public class Phone
    {
        public string PhoneNew { get; set; }
    }
}