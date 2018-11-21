using Application.Common;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveCustomerData : ISaveCustomerData
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        private decimal _percentage = 0;
        public SaveCustomerData(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public bool Save(IEnumerable<CustomerDataModel> customerDataModels, int requestId)
        {
            bool saveStatus = false;
            try
            {
                List<CustomerDataManagement> customerDataManagements = new List<CustomerDataManagement>();

                customerDataManagements.AddRange(
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
                _customerDataManagementContext.Database.SetCommandTimeout(CommonSetting.TimeOut);
                _customerDataManagementContext.BulkInsert(customerDataManagements,
                new BulkConfig
                {
                    PreserveInsertOrder = true,
                    SetOutputIdentity = true,
                    BatchSize = CommonSetting.BulkInsertRange,
                },
                 (a) => WriteProgress(a));

                saveStatus = (CommonSetting.BulkInsertRange <= customerDataManagements.Count()) ? (int)_percentage >= 1 : true;
            }
            catch (Exception)
            {
                throw;
            }
            return saveStatus;
        }
        private void WriteProgress(decimal percentage)
        {
            _percentage = percentage;
        }
    }
}