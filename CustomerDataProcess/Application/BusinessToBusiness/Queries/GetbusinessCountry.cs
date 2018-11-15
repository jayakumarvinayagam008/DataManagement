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
            var country = _customerDataManagementContext.Countries.OrderBy(x => x.Country).ToList();
           
            return country.Where(x => !string.IsNullOrWhiteSpace(x.Country))
                .Select(x =>
            new SelectListItem()
            {
                Value = x.Country,
                Text = x.Country
            }).AsEnumerable<SelectListItem>();
        }
    }
}