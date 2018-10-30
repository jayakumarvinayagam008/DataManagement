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
                            Address = x.Address,
                            Address2 = x.Address2,
                            AnnualSalary = x.AnnualSalary,
                            Area = x.Area,
                            Caste = x.Caste,
                            City = x.City,
                            Country = x.Country,
                            Dob = x.Dob,
                            Email = x.Email,
                            Employer = x.Employer,
                            Experience = x.Experience,
                            Gender = x.Gender,
                            Industry = x.Industry,
                            KeySkills = x.KeySkills,
                            Location = x.Location,
                            Mobile2 = x.Mobile2,
                            MobileNew = x.MobileNew,
                            Name = x.Name,
                            Network = x.Network,
                            PhoneNew = x.PhoneNew,
                            Pincode = x.Pincode,
                            Qualification = x.Qualification,
                            Roles = x.Roles,
                            State = x.State,
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