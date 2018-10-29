using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToBusiness.Queries
{
    public interface IFilterBusinessToBusiness
    {
        BusinessToBusinesListModel Search(BusinessToBusinessFilter businessToBusinessFilter);
    }
}
