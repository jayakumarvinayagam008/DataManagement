using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinessArea : IGetBusinessArea
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessArea(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            var area = _customerDataManagementContext.Area.OrderBy(x => x.Area).ToList();
         
            return area.Where(x => !string.IsNullOrWhiteSpace(x.Area))
                .Select(x =>
            new SelectListItem()
            {
                Value = x.Area,
                Text = x.Area
            }).AsEnumerable<SelectListItem>();
        }
    }
}