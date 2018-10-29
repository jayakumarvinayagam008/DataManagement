using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.CustomerData.Queries
{
    public class FilterCustomerTags : IFilterCustomerTags
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public FilterCustomerTags(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public IEnumerable<int> Filter(int[] tagIds)
        {
            if(tagIds.Any())
            {
                var templateIds = _customerDataManagementContext.CustomerDataManagementTags
                .Join(tagIds, x => x.CustomerDataTagId, y => y, (x, y) => x.RequestId.Value);
                return templateIds;
            }
            return new List<int>();
        }
    }
}
