using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;

namespace Application.CustomerData.Queries
{
    public class GetStates : IGetStates
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetStates(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public IEnumerable<SelectListItem> Get()
        {
            var states = _customerDataManagementContext.CustomerDataManagement
                 .Select(x => x.State)
                 .Where(x => !string.IsNullOrWhiteSpace(x))
                 .Distinct<string>()
                 .OrderBy(x => x).ToArray();

            return states.Select(x => new SelectListItem()
            {
                Value = x,
                Text = x
            }).AsEnumerable<SelectListItem>();
        }
    }
}
