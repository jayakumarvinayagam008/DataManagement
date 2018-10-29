using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToCustomers.Queries
{
    public class GetBusinessToCustomerSalary : IGetBusinessToCustomerSalary
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessToCustomerSalary(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            var salary = _customerDataManagementContext.BusinessToCustomer
                .Select(x => x.AnnualSalary)
                .Distinct();
            return salary.Select(x =>
             new SelectListItem()
             {
                 Value = x,
                 Text = x
             }).AsEnumerable<SelectListItem>();
        }
    }
}