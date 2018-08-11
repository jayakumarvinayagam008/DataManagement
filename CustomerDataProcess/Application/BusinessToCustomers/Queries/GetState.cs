using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.BusinessToCustomers.Queries
{
    public class GetState: IGetState
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        public GetState(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public IEnumerable<SelectListItem> Get()
        {
            var area = _customerDataManagementContext.BusinessToCustomer
                .Select(x => x.State.Trim())
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
