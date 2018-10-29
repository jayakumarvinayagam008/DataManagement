using Application.Common;
using System.Collections.Generic;

namespace Application.BusinessToCustomers.Queries
{
    public class BusinessToCustomerListModel
    {
        public DataFilter Filter { get; set; }
        public IEnumerable<BusinessToCustomerModel> BusinessToCustomers { get; set; }      
        public int SearchCount { get; set; }
        public int Total { get; set; }

    }
}