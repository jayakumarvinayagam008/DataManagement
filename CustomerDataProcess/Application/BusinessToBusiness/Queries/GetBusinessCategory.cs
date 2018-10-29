using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinessCategory : IGetBusinessCategory
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessCategory(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            var categoryId = _customerDataManagementContext.BusinessToBusiness
                          .Select(x => x.CategoryId)
                          .Distinct().AsQueryable();
            var b2bCategory = _customerDataManagementContext.B2bcategory
                .Join(categoryId, x => x.CategoryId, y => y, (x, y) => new SelectListItem()
                {
                    Text = x.Name,
                    Value = $"{x.CategoryId}"
                });
            return b2bCategory;
        }
    }
}