using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Application.BusinessToBusiness.Queries
{
    public interface IGetBusinessStates
    {
        IEnumerable<SelectListItem> Get();
    }
}