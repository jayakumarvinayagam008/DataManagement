using Application.Common;
using System.Collections.Generic;

namespace Application.BusinessToBusiness.Queries
{
    public interface IGetBusinessToBusinessTags
    {
        IEnumerable<Tag> Get();
    }
}