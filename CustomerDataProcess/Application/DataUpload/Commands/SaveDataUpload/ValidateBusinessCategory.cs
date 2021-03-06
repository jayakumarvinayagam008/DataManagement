﻿using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class ValidateBusinessCategory : IValidateBusinessCategoruEntiry
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public ValidateBusinessCategory(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public IEnumerable<int> Validate(IEnumerable<int> categoryId)
        {
            IQueryable<int> businessCategory = _customerDataManagementContext.B2bcategory
               .Select(x => x.CategoryId).AsQueryable<int>();

            var businesCate = categoryId.Intersect(businessCategory).AsEnumerable<int>();
            return businesCate;
        }
    }
}