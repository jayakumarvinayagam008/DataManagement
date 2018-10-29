using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Common;
using Persistance;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinessToBusinessTags : IGetBusinessToBusinessTags
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessToBusinessTags(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public IEnumerable<Tag> Get()
        {
            var tags = _customerDataManagementContext.BusinessToBusinessTags
             .GroupBy(x => x.Tag)
             .Select(x => x.First())
             .Select(x => new Tag { Id = x.BusinessToBusinessTagId, Title = x.Tag })
             .OrderBy(x => x.Id).ToArray();
            return tags;
        }
    }
}
