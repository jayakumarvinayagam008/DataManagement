using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Application.CustomerData.Queries
{
    public interface IGetStates
    {
        IEnumerable<SelectListItem> Get();
    }
}