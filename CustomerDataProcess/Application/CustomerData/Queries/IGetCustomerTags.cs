using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Application.CustomerData.Queries
{
    public interface IGetCustomerTags
    {
        IEnumerable<SelectListItem> Get();
    }
}