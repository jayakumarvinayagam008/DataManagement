using System;
using System.Collections;
using System.Collections.Generic;
using Application.Common;

namespace Application.BusinessToCustomers.Queries
{
    public class BusinessToCustomerListModel
    {
        public DataFilter Filter { get; set; }
        public IEnumerable<BusinessToCustomerModel> BusinessToCustomers { get; set; }
    }
}
