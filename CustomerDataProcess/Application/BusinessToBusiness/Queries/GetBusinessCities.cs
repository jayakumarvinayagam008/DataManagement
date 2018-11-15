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
            var cities = _customerDataManagementContext.Citys.OrderBy(x => x.City).ToList();
           
            return cities.Where(x => !string.IsNullOrWhiteSpace(x.City))
                .Select(x =>
            new SelectListItem()
            {
                Value = x.City,
                Text = x.City
            }).AsEnumerable<SelectListItem>();
        }
    }
}