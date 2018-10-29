using Application.Common;
using Newtonsoft.Json;
using Persistance;

namespace Application.BusinessToCustomers.Queries
{
    public class GetBusinessToCustomer : IGetBusinessToCustomer
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        private readonly IGetBusinessToCustomerCity _getCity;
        private readonly IGetBusinessToCustomerCountry _getCountry;
        private readonly IGetBusinessToCustomerArea _getArea;
        private readonly IGetBusinessToCustomerState _getState;
        private readonly IGetBusinessToCustomerDistinctName _getDestination;
        private readonly IGetBusinessToCustomerSalary _getSalary;
        private readonly IGetBusinessToCustomerAge _getAge;
        private readonly IGetBusinessToCustomerRoles _getRoles;
        private readonly IGetBusinessToCustomerExperience _getExperience;
        private readonly IGetBusinessToCustomerTags _getTags;

        public GetBusinessToCustomer(CustomerDataManagementContext dbContext, IGetBusinessToCustomerArea getArea,
            IGetBusinessToCustomerCity getCity, IGetBusinessToCustomerCountry getCountry,
            IGetBusinessToCustomerState getState, IGetBusinessToCustomerDistinctName getDestination,
            IGetBusinessToCustomerSalary getSalary, IGetBusinessToCustomerAge getAge,
            IGetBusinessToCustomerRoles getRoles, IGetBusinessToCustomerExperience getExperience,
            IGetBusinessToCustomerTags getTags)
        {
            _customerDataManagementContext = dbContext;
            _getArea = getArea;
            _getDestination = getDestination;
            _getState = getState;
            _getCountry = getCountry;
            _getCity = getCity;
            _getSalary = getSalary;
            _getAge = getAge;
            _getRoles = getRoles;
            _getExperience = getExperience;
            _getTags = getTags;
        }

        public BusinessToCustomerListModel Get()
        {
            var filterCity = _getCity.Get();
            var filterState = _getState.Get();
            var filterArea = _getArea.Get();
            var filterCountry = _getCountry.Get();
            var filterRoles = _getRoles.Get();
            var filterSalary = _getSalary.Get();
            var filterExprence = _getExperience.Get();
            var filterAge = _getAge.Get();
            var filterTags = _getTags.Get();
            //var filterDestination = _getDestination.Get();
            //var customer = _customerDataManagementContext.BusinessToCustomer
            //    .OrderByDescending(x => x.CreatedDate)
            //    .Take(5000).Select(cust => new BusinessToCustomerModel
            //    {
            //        Address = cust.Address,
            //        Address2 = cust.Address2,
            //        AnnualSalary = cust.AnnualSalary,
            //        Area = cust.Area,
            //        BusinessToCustomerId = cust.B2cid,
            //        Caste = cust.Caste,
            //        City = cust.City,
            //        Country = cust.Country,
            //        Dob = cust.Dob,
            //        Email = cust.Email,
            //        Employer = cust.Employer,
            //        Experience = cust.Experience,
            //        Gender = cust.Gender,
            //        Industry = cust.Industry,
            //        KeySkills = cust.KeySkills,
            //        Location = cust.Location,
            //        Mobile2 = cust.Mobile2,
            //        MobileNew = cust.MobileNew,
            //        Name = cust.Name,
            //        Network = cust.Network,
            //        PhoneNew = cust.PhoneNew,
            //        Pincode = cust.Pincode,
            //        Qualification = cust.Qualification,
            //        Roles = cust.Roles,
            //        State = cust.State
            //    }).AsEnumerable<BusinessToCustomerModel>();

            return new BusinessToCustomerListModel
            {
                Filter = new DataFilter
                {
                    Area = filterArea,
                    Cities = filterCity,
                    Countries = filterCountry,
                    States = filterState,
                    Ages = filterAge,
                    Roles = filterRoles,
                    Salaries = filterSalary,
                    Expercince = filterExprence,
                    Tags = JsonConvert.SerializeObject(filterTags)
                }
            };
        }
    }
}