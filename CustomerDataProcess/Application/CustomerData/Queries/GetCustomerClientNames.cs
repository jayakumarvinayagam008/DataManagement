using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.CustomerData.Queries
{
    public class GetCustomerClientNames : IGetCustomerClientNames
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetCustomerClientNames(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            var cities = _customerDataManagementContext.CustomerDataManagement

                .Select(x => x.ClientName)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Distinct<string>()
                .OrderBy(x => x).ToArray();

            return cities.Select(x => new SelectListItem()
            {
                Value = x,
                Text = x
            }).AsEnumerable<SelectListItem>();
        }
    }
}