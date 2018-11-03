using Application.Common;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveBusinessToCustomer : ISaveBusinessToCustomer
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public SaveBusinessToCustomer(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public bool Save(IEnumerable<BusinessToCustomerModel> businessToCustomer, int requestId)
        {
            try
            {
                bool status = false;
                _customerDataManagementContext.BusinessToCustomer.AddRange(
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

                status = _customerDataManagementContext.SaveChanges() > 0;
                return status;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}