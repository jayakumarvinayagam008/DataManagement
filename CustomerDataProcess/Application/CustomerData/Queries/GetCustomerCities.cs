using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;

namespace Application.CustomerData.Queries
{
    public class GetCustomerCities : IGetCustomerCities
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        public GetCustomerCities(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public IEnumerable<SelectListItem> Get()
        {
            var cities = _customerDataManagementContext.CustomerDataManagement

                .Select(x => x.ClientCity)
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
