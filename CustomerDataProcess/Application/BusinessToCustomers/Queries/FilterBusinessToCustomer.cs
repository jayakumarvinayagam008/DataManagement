using Application.Common;
using Persistance;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.BusinessToCustomers.Queries
{
    public class FilterBusinessToCustomer : IFilterBusinessToCustomer
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        private readonly IFilterBusinessToCustomerTags _getBusinessToCustomerTags;

        public FilterBusinessToCustomer(CustomerDataManagementContext customerDataManagementContext,
            IFilterBusinessToCustomerTags getBusinessToCustomerTags)
        {
            _customerDataManagementContext = customerDataManagementContext;
            _getBusinessToCustomerTags = getBusinessToCustomerTags;
        }

        public BusinessToCustomerListModel Search(BusinessToCustomerFilter businessToCustomerFilter)
        {
            var today = DateTime.Now;
            
            var country = string.Join(",", businessToCustomerFilter.Countries);
            var state = string.Join(",", businessToCustomerFilter.States);
            var city = string.Join(",", businessToCustomerFilter.Cities);
            var area = string.Join(",", businessToCustomerFilter.Areas);
            var role = string.Join(",", businessToCustomerFilter.Roles);
            var salary = string.Join(",", businessToCustomerFilter.Salaries);
            var age = string.Empty;
            var experience = string.Join(",", businessToCustomerFilter.Experience);
            var tags = string.Join(",", businessToCustomerFilter.Tags);
            var b2cFilter = _customerDataManagementContext.BusinessToCustomer
                .FromSql("EXECUTE dm.usp_SearchBusinessToCustomer @p0, @p1,@p2, @p3,@p4, @p5,@p6, @p7, @p8"
                , parameters: new[] { country, state, city, area, role, salary, area, experience, tags }).ToList();
            if (businessToCustomerFilter.Age.Any())
            {
                b2cFilter = b2cFilter.Where(x => businessToCustomerFilter.Age.Any(y => y == x.Dob.Value.Age(today))).ToList();
            }
           
            var b2cSearchResult = b2cFilter.Select(x => new BusinessToCustomerModel
            {
                Address = x.Address,
                Address2 = x.Address2,
                AnnualSalary = x.AnnualSalary,
                Area = x.Area,
                Caste = x.Caste,
                City = x.City,
                Country = x.Country,
                Dob = x.Dob.Value,
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
                State = x.State
            }).ToList();
            var buusiness2CustomerTotal = _customerDataManagementContext.BusinessToCustomer.Count();
            return new BusinessToCustomerListModel
            {
                Filter = null,
                BusinessToCustomers = b2cSearchResult,
                SearchCount = b2cSearchResult.Count(),
                Total = buusiness2CustomerTotal
            };
        }
    }
}