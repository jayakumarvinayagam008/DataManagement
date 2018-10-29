using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinessCities : IGetBusinessCities
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessCities(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            var area = _customerDataManagementContext.BusinessToBusiness
               .Select(x => x.City.Trim())
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