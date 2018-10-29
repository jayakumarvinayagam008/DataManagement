using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToCustomers.Queries
{
    public class GetBusinessToCustomerCity : IGetBusinessToCustomerCity
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessToCustomerCity(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            var area = _customerDataManagementContext.BusinessToCustomer
                .Select(x => x.City.Trim())
                .Distinct<string>()
                .OrderBy(x => x).ToArray();

            return area.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x =>
             new SelectListItem()
             {
                 Value = x,
                 Text = x
             }).AsEnumerable<SelectListItem>();
        }
    }
}