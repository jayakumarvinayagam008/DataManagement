using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToBusiness.Queries
{
    public interface IGetBusinessToBusinessTags
    {
        IEnumerable<Tag> Get();
    }
}
