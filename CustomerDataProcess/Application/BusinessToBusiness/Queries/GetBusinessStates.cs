﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinessStates : IGetBusinessStates
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessStates(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            var state = _customerDataManagementContext.States.OrderBy(x => x.State).ToList();
           
            return state.Where(x => !string.IsNullOrWhiteSpace(x.State))
                .Select(x =>
            new SelectListItem()
            {
                Value = x.State,
                Text = x.State
            }).AsEnumerable<SelectListItem>();
        }
    }
}