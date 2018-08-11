using Application.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToCustomers.Queries
{
    public interface IGetDistinctName
    {
        IEnumerable<SelectListItem> Get();
    }
}
