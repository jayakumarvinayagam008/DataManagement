using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToBusiness.Queries
{
    public interface IFilterBusinessToBusinessTags
    {
        IEnumerable<int> Filter(int[] tagIds);
    }
}
