using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Application.CustomerData.Queries
{
    public interface IGetCustomerCountry
    {
        IEnumerable<SelectListItem> Get();
    }
}