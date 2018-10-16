using System;
using System.Linq;
using Application.Common;
using Persistance;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinessToBusiness:IGetBusinessToBusiness
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        private readonly IGetBusinessCities _getCity;
        private readonly IGetBusinessCountry _getCountry;
        private readonly IGetBusinessArea _getArea;
        private readonly IGetBusinessStates _getState;
        private readonly IGetBusinessDestination _getDestination;
        public GetBusinessToBusiness(CustomerDataManagementContext dbContext,
            IGetBusinessCities getCity, IGetBusinessCountry getCountry, IGetBusinessArea getArea,
            IGetBusinessStates getState, IGetBusinessDestination getDestination)
        {
            _customerDataManagementContext = dbContext;
            _getCity = getCity;
            _getCountry = getCountry;
            _getArea = getArea;
            _getState = getState;
            _getDestination = getDestination;
        }

        public BusinessToBusinesListModel Get()
        {
            var filterCity = _getCity.Get();
            var filterState = _getState.Get();
            var filterArea = _getArea.Get();
            var filterCountry = _getCountry.Get();
            var filterDestination = _getDestination.Get();
            
            var customer = _customerDataManagementContext.BusinessToBusiness.OrderByDescending(x=>x.CreatedDate ).Take(5000)
                                                         .Select(cust =>
                                                                      new BusinessToBusinesModel
                                                                      {
                                                                          Add1 = cust.Add1,
                                                                          Add2 = cust.Add2,
                                                                          Area = cust.Area,
                                                                          CategoryId = cust.CategoryId,
                                                                          CategoryName = cust.Category.Name,
                                                                          City = cust.City,
                                                                          CompanyName = cust.CompanyName,
                                                                          ContactPerson = cust.ContactPerson,
                                                                          Contactperson1 = cust.Contactperson1,
                                                                          Designation = cust.Designation,
                                                                          Designation1 = cust.Designation1,
                                                                          Email = cust.Email,
                                                                          Email1 = cust.Email1,
                                                                          EstYear = cust.EstYear,
                                                                          Fax = cust.Fax,
                                                                          Id = cust.Id,
                                                                          LandMark = cust.LandMark,
                                                                          Mobile1 = cust.Mobile1,
                                                                          MobileNew = cust.MobileNew,
                                                                          Mobile2 = cust.Mobile2,
                                                                          NoOfEmp = cust.NoOfEmp,
                                                                          Phone1 = cust.Phone1,
                                                                          Phone2 = cust.Phone2,
                                                                          PhoneNew = cust.PhoneNew,
                                                                          Pincode = cust.Pincode,
                                                                          State = cust.State,
                                                                          Web = cust.Web,
                                                                          Country = cust.Country
                                                                      }).AsEnumerable<BusinessToBusinesModel>();
            return new BusinessToBusinesListModel
            {
                BusinessToBusiness = customer,
                Filter = new DataFilter
                {
                    Area = filterArea,
                    Cities = filterCity,
                    Countries = filterCountry,
                    Desigination = filterDestination,
                    States = filterState
                }
            };
        }
    }
}
