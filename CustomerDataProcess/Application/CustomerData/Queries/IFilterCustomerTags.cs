using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Queries
{
    public interface IFilterCustomerTags
    {
        IEnumerable<int> Filter(int[] tagIds);
    }
}
