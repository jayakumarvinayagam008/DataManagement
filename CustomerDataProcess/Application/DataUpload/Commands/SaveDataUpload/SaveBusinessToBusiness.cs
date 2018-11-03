﻿using Application.Common;
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

        public bool Save(IEnumerable<BusinessToBusinesModel> customerToBusiness, int requestId)
        {
            bool status = false;
            _customerDataManagementContext.BusinessToBusiness.AddRange(
                customerToBusiness.Select(x => new Persistance.BusinessToBusiness()
                {
                    Add1 = x.Add1?.Trim(),
                    Add2 = x.Add2?.Trim(),
                    Area = x.Area?.Trim(),
                    CategoryId = x.CategoryId,
                    City = x.City?.Trim(),
                    CompanyName = x.CompanyName?.Trim(),
                    ContactPerson = x.ContactPerson?.Trim(),
                    Contactperson1 = x.Contactperson1?.Trim(),
                    Country = x.Country?.Trim(),
                    Designation = x.Designation?.Trim(),
                    Designation1 = x.Designation1?.Trim(),
                    Email = x.Email?.Trim(),
                    Email1 = x.Email1?.Trim(),
                    EstYear = x.EstYear,
                    Fax = x.Fax?.Trim(),
                    LandMark = x.LandMark?.Trim(),
                    Mobile1 = x.Mobile1?.Trim(),
                    Mobile2 = x.Mobile2?.Trim(),
                    MobileNew = x.MobileNew?.Trim(),
                    NoOfEmp = x.NoOfEmp,
                    Phone1 = x.Phone1?.Trim(),
                    Phone2 = x.Phone2?.Trim(),
                    PhoneNew = x.PhoneNew?.Trim(),
                    Pincode = x.Pincode?.Trim(),
                    State = x.State?.Trim(),
                    Web = x.Web?.Trim(),
                    RequestId = requestId
                }));
            status = _customerDataManagementContext.SaveChanges() > 0;
            return status;
        }
    }
}