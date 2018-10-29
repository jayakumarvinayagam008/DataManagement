using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToCustomers.Queries
{
    public interface IFilterBusinessToCustomerTags
    {
        IEnumerable<int> Filter(int[] tagIds);
    }
}
