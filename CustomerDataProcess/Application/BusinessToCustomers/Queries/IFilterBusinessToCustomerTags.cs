using System.Collections.Generic;

namespace Application.BusinessToCustomers.Queries
{
    public interface IFilterBusinessToCustomerTags
    {
        IEnumerable<int> Filter(int[] tagIds);
    }
}