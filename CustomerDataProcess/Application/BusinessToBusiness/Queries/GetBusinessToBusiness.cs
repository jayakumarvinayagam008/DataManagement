using System;
using System.Linq;
using Application.Common;
using Persistance;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinessToBusiness:IGetBusinessToBusiness
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        public GetBusinessToBusiness(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public BusinessToBusinesListModel Get()
        {
            var customer = _customerDataManagementContext.BusinessToBusiness
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
            return new BusinessToBusinesListModel { BusinessToBusiness = customer };
        }
    }
}
