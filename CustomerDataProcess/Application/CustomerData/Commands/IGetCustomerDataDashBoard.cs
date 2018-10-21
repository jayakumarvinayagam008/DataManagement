using Application.CustomerData.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Commands
{
    public interface IGetCustomerDataDashBoard
    {
        CustomerDataDashBoard CalculateDashBoard(CustomerListDataModel customerListDataModel);
    }
}
