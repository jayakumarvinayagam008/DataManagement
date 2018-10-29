using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.CustomerData.Queries
{
    public class GetCustomerTags : IGetCustomerTags
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetCustomerTags(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public IEnumerable<Tag> Get()
        {
            var tags = _customerDataManagementContext.CustomerDataManagementTags
                .GroupBy(x => x.Tag)
                .Select(x => x.First())
                .Select(x => new Tag { Id = x.CustomerDataTagId, Title = x.Tag })
                .OrderBy(x => x.Id).ToArray();
            return tags;
        }
    }
}