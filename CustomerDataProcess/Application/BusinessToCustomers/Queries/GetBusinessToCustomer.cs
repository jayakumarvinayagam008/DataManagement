using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Application.Common;
using Persistance;

namespace Application.BusinessToCustomers.Queries
{
    public class GetBusinessToCustomer:IGetBusinessToCustomer
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        private readonly IGetCity _getCity;
        private readonly IGetCountry _getCountry;
        private readonly IGetArea _getArea;
        private readonly IGetState _getState;
        private readonly IGetDistinctName _getDestination;
        
        public GetBusinessToCustomer(CustomerDataManagementContext dbContext, IGetArea getArea,
            IGetCity getCity, IGetCountry getCountry, IGetState getState, IGetDistinctName getDestination)
        {
            _customerDataManagementContext = dbContext;
            _getArea = getArea;
            _getDestination = getDestination;
            _getState = getState;
            _getCountry = getCountry;
            _getCity = getCity;
        }

        public BusinessToCustomerListModel Get()
        {
            var filterCity = _getCity.Get();
            var filterState = _getState.Get();
            var filterArea = _getArea.Get();
            var filterCountry = _getCountry.Get();
            //var filterDestination = _getDestination.Get();
            var customer = _customerDataManagementContext.BusinessToCustomer
                .OrderByDescending(x => x.CreatedDate)
                .Take(5000).Select(cust => new BusinessToCustomerModel
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
            return new BusinessToCustomerListModel
            {
                BusinessToCustomers = customer,
                Filter = new DataFilter
                {
                    Area = filterArea,
                    Cities = filterCity,
                    Countries = filterCountry,
                    States = filterState
                }
            };
        }
    }
}
