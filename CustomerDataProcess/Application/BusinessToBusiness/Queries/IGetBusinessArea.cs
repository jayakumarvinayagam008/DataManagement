using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Application.BusinessToBusiness.Queries
{
    public interface IGetBusinessArea
    {
        IEnumerable<SelectListItem> Get();
    }
}