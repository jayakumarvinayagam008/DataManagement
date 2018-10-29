using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToCustomers.Queries
{
    public interface IFilterBusinessToCustomer
    {
        BusinessToCustomerListModel Search(BusinessToCustomerFilter businessToCustomerFilter);
    }
}
