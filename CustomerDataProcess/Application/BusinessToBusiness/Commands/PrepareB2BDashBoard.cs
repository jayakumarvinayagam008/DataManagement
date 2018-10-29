using Application.BusinessToBusiness.Queries;
using System;
using System.Linq;

namespace Application.BusinessToBusiness.Commands
{
    public class PrepareB2BDashBoard : IPrepareB2BDashBoard
    {
        public BusinessToBusinessDashBoard Prepare(BusinessToBusinesListModel businessToBusinesListModel)
        {
            BusinessToBusinessDashBoard businessToBusinessDashBoard = new BusinessToBusinessDashBoard() {
                Total = businessToBusinesListModel.Total,
                SearchCount = businessToBusinesListModel.SearchCount,
                Add1 = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Add1))
                        .Select(x => x.Add1).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Add2 = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Add2))
                        .Select(x => x.Add2).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Area = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Area))
                        .Select(x => x.Area).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                CategoryId = (businessToBusinesListModel.BusinessToBusiness.Select(x => x.CategoryId).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                City = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.City))
                        .Select(x => x.City).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                CompanyName = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.CompanyName))
                        .Select(x => x.CompanyName).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                ContactPerson = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.ContactPerson))
                        .Select(x => x.ContactPerson).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Contactperson1 = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Contactperson1))
                        .Select(x => x.Contactperson1).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Country = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Country))
                        .Select(x => x.Country).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Designation = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Designation))
                        .Select(x => x.Designation).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Designation1 = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Designation1))
                        .Select(x => x.Designation1).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Email = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Email))
                        .Select(x => x.Email).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Email1 = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Email1))
                        .Select(x => x.Email1).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                EstYear = (businessToBusinesListModel.BusinessToBusiness.Select(x => x.EstYear).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Fax = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Fax))
                        .Select(x => x.Fax).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                LandMark = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.LandMark))
                        .Select(x => x.LandMark).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Mobile1 = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Mobile1))
                        .Select(x => x.Mobile1).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Mobile2 = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Mobile2))
                        .Select(x => x.Mobile2).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                MobileNew = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.MobileNew))
                        .Select(x => x.MobileNew).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                NoOfEmp = (businessToBusinesListModel.BusinessToBusiness.Select(x => x.NoOfEmp).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Phone1 = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Phone1))
                        .Select(x => x.Phone1).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Phone2 = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Phone2))
                        .Select(x => x.Phone2).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                PhoneNew = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.PhoneNew))
                        .Select(x => x.PhoneNew).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Pincode = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Pincode))
                        .Select(x => x.Pincode).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                State =(businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.State))
                        .Select(x => x.State).Count() / (decimal)businessToBusinesListModel.Total) * 100,

                Web = (businessToBusinesListModel.BusinessToBusiness.Where(x => !string.IsNullOrWhiteSpace(x.Web))
                        .Select(x => x.Web).Count() / (decimal)businessToBusinesListModel.Total) * 100,

            };
            return businessToBusinessDashBoard;
        }
    }
}
