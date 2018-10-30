using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveCustomerData : ISaveCustomerData
    {
        private readonly CustomerDataManagementContext customerDataManagementContext;

        public SaveCustomerData(CustomerDataManagementContext dbContext)
        {
            customerDataManagementContext = dbContext;
        }

        public bool Save(IEnumerable<CustomerDataModel> customerDataModels, int requestId)
        {
            bool saveStatus = false;
            try
            {
                customerDataManagementContext.CustomerDataManagement.AddRange(
                    customerDataModels.Select(x => new CustomerDataManagement
                    {
                        Circle = x.Circle,
                        ClientBusinessVertical = x.ClientBusinessVertical,
                        ClientCity = x.ClientCity,
                        ClientName = x.ClientName,
                        DateOfUse = x.DateOfUse,
                        Numbers = x.Numbers,
                        Operator = x.Operator,
                        Dbquality = x.DBQuality,
                        CreatedBy = x.UpdatedBy,
                        CreatedDate = x.UpdatedOn,
                        ModifiedBy = x.UpdatedBy,
                        ModifiedDate = x.UpdatedOn,
                        RequestId = requestId
                    }));
                saveStatus = customerDataManagementContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return saveStatus;
        }
    }
}