﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Application.BusinessToCustomers.Queries
{
    public interface IGetBusinessToCustomerCity
    {
        IEnumerable<SelectListItem> Get();
    }
}