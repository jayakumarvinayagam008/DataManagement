using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Queries
{
    public interface IGetCustomerClientNames
    {
        IEnumerable<SelectListItem> Get();
    }
}
