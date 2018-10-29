using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.BusinessToCustomers.Queries
{
    public class FilterBusinessToCustomerTags : IFilterBusinessToCustomerTags
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public FilterBusinessToCustomerTags(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public IEnumerable<int> Filter(int[] tagIds)
        {
            if (tagIds.Any())
            {
                var templateIds = _customerDataManagementContext.BusinessToCustomerTags
                .Join(tagIds, x => x.BusinessToCustomerTagId, y => y, (x, y) => x.RequestId.Value);
                return templateIds;
            }
            return new List<int>();
        }
    }
}
