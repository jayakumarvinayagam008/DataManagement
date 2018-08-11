using Application.DataUpload.Commands.SaveDataUpload;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.CustomerData.Queries
{
    public class GetCustomerData : IGetCustomerData
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        public GetCustomerData(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public CustomerListDataModel Get()
        {

            var customerData = _customerDataManagementContext.CustomerDataManagement
                .Select(x => new CustomerDataModel
                {
                    Circle = x.Circle,
                    ClientBusinessVertical = x.ClientBusinessVertical,
                    ClientCity = x.ClientCity,
                    ClientName = x.ClientName,
                    DateOfUse = x.DateOfUse.Value,
                    DBQuality = x.Dbquality,
                    Numbers = x.Numbers,
                    Operator = x.Operator
                }).AsEnumerable<CustomerDataModel>();
            return new CustomerListDataModel { CustomerDataModels = customerData, Filter = new Common.DataFilter {
                Countries = null
            } };
        }
    }
}
