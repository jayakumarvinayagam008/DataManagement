using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinessDestination : IGetBusinessDestination
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        public GetBusinessDestination(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }
        public IEnumerable<SelectListItem> Get()
        {
            var area = _customerDataManagementContext.BusinessToBusiness
                .Select(x => x.Designation.Trim())
                .Distinct<string>()
                .OrderBy(x => x).ToArray();
            int areaId = 0;

            return area.Where(x=> !string.IsNullOrWhiteSpace(x))
                .Select(x =>
            new SelectListItem()
            {
                Value = $"{++areaId}",
                Text = x
            }).AsEnumerable<SelectListItem>();
        }
    }
}
