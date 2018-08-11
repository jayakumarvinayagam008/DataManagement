using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;

namespace Application.BusinessToCustomers.Queries
{
    public class GetDestination : IGetDistinctName
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        public GetDestination(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public IEnumerable<SelectListItem> Get()
        {
            var area = _customerDataManagementContext.BusinessToBusiness
                .Select(x => x.Designation.Trim())
                .Distinct<string>()
                .OrderBy(x => x).ToArray();
            int areaId = 0;

            return area.Select(x =>
            new SelectListItem()
            {
                Value = $"{++areaId}",
                Text = x
            }).AsEnumerable<SelectListItem>();
        }
    }
}
