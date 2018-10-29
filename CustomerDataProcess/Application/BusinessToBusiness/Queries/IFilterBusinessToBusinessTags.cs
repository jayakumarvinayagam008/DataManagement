using System.Collections.Generic;

namespace Application.BusinessToBusiness.Queries
{
    public interface IFilterBusinessToBusinessTags
    {
        IEnumerable<int> Filter(int[] tagIds);
    }
}