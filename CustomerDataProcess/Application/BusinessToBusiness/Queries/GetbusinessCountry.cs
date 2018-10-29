using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinessCountry : IGetBusinessCountry
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessCountry(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            var area = _customerDataManagementContext.BusinessToBusiness
                           .Select(x => x.Country.Trim())
                           .Distinct<string>()
                           .OrderBy(x => x).ToArray();

            return area.Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x =>
            new SelectListItem()
            {
                Value = x,
                Text = x
            }).AsEnumerable<SelectListItem>();
        }
    }
}