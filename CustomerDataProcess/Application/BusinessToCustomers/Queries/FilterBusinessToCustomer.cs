using Application.Common;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                        
           var b2cFilter =  _customerDataManagementContext.BusinessToCustomer.AsQueryable();
            // 1.Country
            if(businessToCustomerFilter.Countries.Any())
            {
                b2cFilter = b2cFilter.Where(x=> businessToCustomerFilter.Countries.Any(y=> y == x.Country)).AsQueryable();
            }
            //2./State
            if (businessToCustomerFilter.States.Any())
            {
                b2cFilter = b2cFilter.Where(x => businessToCustomerFilter.States.Any(y => y == x.State)).AsQueryable();
            }
            //3.city
            if (businessToCustomerFilter.Cities.Any())
            {
                b2cFilter = b2cFilter.Where(x => businessToCustomerFilter.Cities.Any(y => y == x.City)).AsQueryable();
            }
            //4.Area
            if (businessToCustomerFilter.Areas.Any())
            {
                b2cFilter = b2cFilter.Where(x => businessToCustomerFilter.Areas.Any(y => y == x.Area)).AsQueryable();
            }
            //5.Role
            if (businessToCustomerFilter.Roles.Any())
            {
                b2cFilter = b2cFilter.Where(x => businessToCustomerFilter.Roles.Any(y => y == x.Roles)).AsQueryable();
            }
            //6.Salary
            if (businessToCustomerFilter.Salaries.Any())
            {
                b2cFilter = b2cFilter.Where(x => businessToCustomerFilter.Salaries.Any(y => y == x.AnnualSalary)).AsQueryable();
            }
            //7.Age
            if (businessToCustomerFilter.Age.Any())
            {
               //b2cFilter = b2cFilter.Where(x => businessToCustomerFilter.Age.Any(y => y == x.AnnualSalary)).AsQueryable();
            }
            //8.Experience
            if (businessToCustomerFilter.Experience.Any())
            {
                b2cFilter = b2cFilter.Where(x => businessToCustomerFilter.Experience.Any(y => y == x.Experience)).AsQueryable();
            }
            //9.Tag
            var tags = _getBusinessToCustomerTags.Filter(businessToCustomerFilter.Tags).ToList();
            if (tags.Any())
            {
                b2cFilter = b2cFilter.Where(x => tags.Any(y => y == x.RequestId)).AsQueryable();
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
