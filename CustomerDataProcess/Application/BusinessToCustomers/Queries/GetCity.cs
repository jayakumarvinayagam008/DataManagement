﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.BusinessToCustomers.Queries
{
    public class GetCity : IGetCity
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        public GetCity(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public IEnumerable<SelectListItem> Get()
        {
            var area = _customerDataManagementContext.BusinessToCustomer
                .Select(x => x.City.Trim())
                .Distinct<string>()
                .OrderBy(x => x).ToArray();

            return area.Where(x=> !string.IsNullOrWhiteSpace(x)).Select(x =>
            new SelectListItem()
            {
                Value = x,
                Text = x
            }).AsEnumerable<SelectListItem>();
        }
    }
}
