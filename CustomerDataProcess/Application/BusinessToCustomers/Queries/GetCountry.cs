using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;

namespace Application.BusinessToCustomers.Queries
{
    public class GetCountry : IGetCountry
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        public GetCountry(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public IEnumerable<SelectListItem> Get()
        {
            var area = _customerDataManagementContext.BusinessToCustomer
                .Select(x => x.Country.Trim())
                .Distinct<string>()
                .OrderBy(x => x).ToArray();
            int areaId = 0;

            return area.Where(x=> !string.IsNullOrWhiteSpace(x)).Select(x =>
            new SelectListItem()
            {
                Value = $"{++areaId}",
                Text = x
            }).AsEnumerable<SelectListItem>();
        }
    }
}
