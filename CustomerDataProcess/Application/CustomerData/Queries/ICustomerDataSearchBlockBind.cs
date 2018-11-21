using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Queries
{
    public interface ICustomerDataSearchBlockBind
    {
        CustomerDataSearchBlock Fetch();
    }
}
