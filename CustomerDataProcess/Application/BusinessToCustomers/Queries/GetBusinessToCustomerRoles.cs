using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToCustomers.Queries
{
    public class GetBusinessToCustomerRoles : IGetBusinessToCustomerRoles
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessToCustomerRoles(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            var salary = _customerDataManagementContext.BusinessToCustomer
                .Select(x => x.Roles)
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