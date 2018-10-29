using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToBusiness.Queries
{
    public interface IGetBusinessCategory
    {
        IEnumerable<SelectListItem> Get();
    }
}
