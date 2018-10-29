using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToBusiness.Queries
{
    public class FilterBusinessToBusinessTags : IFilterBusinessToBusinessTags
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public FilterBusinessToBusinessTags(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public IEnumerable<int> Filter(int[] tagIds)
        {
            if (tagIds.Any())
            {
                var templateIds = _customerDataManagementContext.BusinessToBusinessTags
                .Join(tagIds, x => x.BusinessToBusinessTagId, y => y, (x, y) => x.RequestId.Value);
                return templateIds;
            }
            return new List<int>();
        }
    }
}