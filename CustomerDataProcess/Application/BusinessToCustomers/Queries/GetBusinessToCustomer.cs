using System;
using System.Linq;
using Application.Common;
using Persistance;

namespace Application.BusinessToCustomers.Queries
{
    public class GetBusinessToCustomer:IGetBusinessToCustomer
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        public GetBusinessToCustomer(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public BusinessToCustomerListModel Get()
        {
            var customer = _customerDataManagementContext.BusinessToCustomer.Select(cust => new BusinessToCustomerModel
            {
                Address = cust.Address,
                Address2 = cust.Address2,
                AnnualSalary = cust.AnnualSalary,
                Area = cust.Area,
                BusinessToCustomerId = cust.B2cid,
                Caste = cust.Caste,
                City = cust.City,
                Country = cust.Country,
                Dob = cust.Dob,
                Email = cust.Email,
                Employer = cust.Employer,
                Experience = cust.Experience,
                Gender = cust.Gender,
                Industry = cust.Industry,
                KeySkills = cust.KeySkills,
                Location = cust.Location,
                Mobile2 = cust.Mobile2,
                MobileNew = cust.MobileNew,
                Name = cust.Name,
                Network = cust.Network,
                PhoneNew = cust.PhoneNew,
                Pincode = cust.Pincode,
                Qualification = cust.Qualification,
                Roles = cust.Roles,
                State = cust.State
            }).AsEnumerable<BusinessToCustomerModel>();
            return new BusinessToCustomerListModel { BusinessToCustomers = customer };
        }
    }
}
