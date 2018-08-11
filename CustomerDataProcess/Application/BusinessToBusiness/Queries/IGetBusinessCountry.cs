using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Application.BusinessToBusiness.Queries
{
    public interface IGetBusinessCountry
    {
        IEnumerable<SelectListItem> Get();
    }
}