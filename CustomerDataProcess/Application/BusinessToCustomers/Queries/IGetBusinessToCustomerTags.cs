using Application.Common;
using System.Collections.Generic;

namespace Application.BusinessToCustomers.Queries
{
    public interface IGetBusinessToCustomerTags
    {
        IEnumerable<Tag> Get();
    }
}