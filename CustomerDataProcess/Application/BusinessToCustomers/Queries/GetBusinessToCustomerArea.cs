using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToCustomers.Queries
{
    public class GetBusinessToCustomerArea : IGetBusinessToCustomerArea
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessToCustomerArea(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            var area = _customerDataManagementContext.BusinessToCustomer
                .Select(x => x.Area.Trim())
                .Distinct<string>()
                .OrderBy(x => x).ToArray();

            return area.Where(x => !string.IsNullOrEmpty(x)).Select(x =>
             new SelectListItem()
             {
                 Value = x,
                 Text = x
             }).AsEnumerable<SelectListItem>();
        }
    }
}