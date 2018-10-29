using Application.Common;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToCustomers.Queries
{
    public class GetBusinessToCustomerTags : IGetBusinessToCustomerTags
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessToCustomerTags(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public IEnumerable<Tag> Get()
        {
            var tags = _customerDataManagementContext.BusinessToCustomerTags
              .GroupBy(x => x.Tag)
              .Select(x => x.First())
              .Select(x => new Tag { Id = x.BusinessToCustomerTagId, Title = x.Tag })
              .OrderBy(x => x.Id).ToArray();
            return tags;
        }
    }
}