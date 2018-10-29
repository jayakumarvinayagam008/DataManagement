using System.Collections.Generic;

namespace Application.CustomerData.Queries
{
    public interface IFilterCustomerTags
    {
        IEnumerable<int> Filter(int[] tagIds);
    }
}