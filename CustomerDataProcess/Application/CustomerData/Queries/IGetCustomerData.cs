using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Queries
{
    public interface IGetCustomerData
    {
        CustomerListDataModel Get();
    }
}
