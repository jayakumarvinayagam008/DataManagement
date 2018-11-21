using Application.Common;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveBusinessToCustomer : ISaveBusinessToCustomer
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        private decimal _percentage = 0;
        public SaveBusinessToCustomer(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public bool Save(IEnumerable<BusinessToCustomerModel> businessToCustomer, int requestId)
        {
            try
            {
                bool status = false;
                List<Persistance.BusinessToCustomer> businessToCustomers = new List<BusinessToCustomer>();

                businessToCustomers.AddRange(
                    businessToCustomer.Select(
                        x => new Persistance.BusinessToCustomer
                        {
                            Address = x.Address?.Trim(),
                            Address2 = x.Address2,
                            AnnualSalary = x.AnnualSalary?.Trim(),
                            Area = x.Area?.Trim(),
                            Caste = x.Caste?.Trim(),
                            City = x.City?.Trim(),
                            Country = x.Country?.Trim(),
                            Dob = x.Dob,
                            Email = x.Email?.Trim(),
                            Employer = x.Employer?.Trim(),
                            Experience = x.Experience?.Trim(),
                            Gender = x.Gender?.Trim(),
                            Industry = x.Industry?.Trim(),
                            KeySkills = x.KeySkills?.Trim(),
                            Location = x.Location?.Trim(),
                            Mobile2 = x.Mobile2?.Trim(),
                            MobileNew = x.MobileNew?.Trim(),
                            Name = x.Name?.Trim(),
                            Network = x.Network?.Trim(),
                            PhoneNew = x.PhoneNew?.Trim(),
                            Pincode = x.Pincode?.Trim(),
                            Qualification = x.Qualification?.Trim(),
                            Roles = x.Roles?.Trim(),
                            State = x.State?.Trim(),
                            RequestId = requestId
                        }));
                _customerDataManagementContext.Database.SetCommandTimeout(CommonSetting.TimeOut);

                _customerDataManagementContext.BulkInsert(businessToCustomers,
                new BulkConfig
                {
                    PreserveInsertOrder = true,
                    SetOutputIdentity = true,
                    BatchSize = CommonSetting.BulkInsertRange,
                },
                 (a) => WriteProgress(a));

                status = (CommonSetting.BulkInsertRange <= businessToCustomer.Count()) ? (int)_percentage >= 1 : true;
                return status;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void WriteProgress(decimal percentage)
        {
            _percentage = percentage;
        }
    }
}