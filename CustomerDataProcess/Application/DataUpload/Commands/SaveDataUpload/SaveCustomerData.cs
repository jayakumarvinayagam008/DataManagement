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
                        Circle = x.Circle?.Trim(),
                        ClientBusinessVertical = x.ClientBusinessVertical?.Trim(),
                        ClientCity = x.ClientCity?.Trim(),
                        ClientName = x.ClientName?.Trim(),
                        DateOfUse = x.DateOfUse,
                        Numbers = x.Numbers?.Trim(),
                        Operator = x.Operator?.Trim(),
                        Dbquality = x.DBQuality?.Trim(),
                        CreatedBy = x.UpdatedBy?.Trim(),
                        CreatedDate = x.UpdatedOn,
                        ModifiedBy = x.UpdatedBy?.Trim(),
                        ModifiedDate = x.UpdatedOn,
                        RequestId = requestId,
                        Country = x.Country,
                        State = x.State
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