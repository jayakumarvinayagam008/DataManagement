using Application.Common;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveBusinessToBusiness : ISaveBusinessToBusiness
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public SaveBusinessToBusiness(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public bool Save(IEnumerable<BusinessToBusinesModel> customerToBusiness)
        {
            bool status = false;
            _customerDataManagementContext.BusinessToBusiness.AddRange(
                customerToBusiness.Select(x => new Persistance.BusinessToBusiness()
                {
                    Add1 = x.Add1,
                    Add2 = x.Add2,
                    Area = x.Area,
                    CategoryId = x.CategoryId,
                    City = x.City,
                    CompanyName = x.CompanyName,
                    ContactPerson = x.ContactPerson,
                    Contactperson1 = x.Contactperson1,
                    Country = x.Country,
                    Designation = x.Designation,
                    Designation1 = x.Designation1,
                    Email = x.Email,
                    Email1 = x.Email1,
                    EstYear = x.EstYear,
                    Fax = x.Fax,
                    LandMark = x.LandMark,
                    Mobile1 = x.Mobile1,
                    Mobile2 = x.Mobile2,
                    MobileNew = x.MobileNew,
                    NoOfEmp = x.NoOfEmp,
                    Phone1 = x.Phone1,
                    Phone2 = x.Phone2,
                    PhoneNew = x.PhoneNew,
                    Pincode = x.Pincode,
                    State = x.State,
                    Web = x.Web
                }));
            status = _customerDataManagementContext.SaveChanges() > 0;
            return status;
        }
    }
}