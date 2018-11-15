using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

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
            var destination = _customerDataManagementContext.DestiantionViews.OrderBy(x => x.Designation).ToList();            
            return destination.Where(x => !string.IsNullOrWhiteSpace(x.Designation))
                .Select(x =>
            new SelectListItem()
            {
                Value = x.Designation,
                Text = x.Designation
            }).AsEnumerable<SelectListItem>();
        }
    }
}