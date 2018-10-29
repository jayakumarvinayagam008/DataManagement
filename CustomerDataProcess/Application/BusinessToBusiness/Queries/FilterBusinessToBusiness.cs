using Application.Common;
using Persistance;
using System.Linq;

namespace Application.BusinessToBusiness.Queries
{
    public class FilterBusinessToBusiness : IFilterBusinessToBusiness
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        private readonly IFilterBusinessToBusinessTags _getBusinessToBusinessTags;

        public FilterBusinessToBusiness(CustomerDataManagementContext customerDataManagementContext,
            IFilterBusinessToBusinessTags getBusinessToBusinessTags)
        {
            _customerDataManagementContext = customerDataManagementContext;
            _getBusinessToBusinessTags = getBusinessToBusinessTags;
        }

        public BusinessToBusinesListModel Search(BusinessToBusinessFilter businessToBusinessFilter)
        {
            var b2bFilter = _customerDataManagementContext.BusinessToBusiness.AsQueryable();
            // 1.Country
            if (businessToBusinessFilter.Countries.Any())
            {
                b2bFilter = b2bFilter.Where(x => businessToBusinessFilter.Countries.Any(y => y == x.Country)).AsQueryable();
            }
            //2./State
            if (businessToBusinessFilter.States.Any())
            {
                b2bFilter = b2bFilter.Where(x => businessToBusinessFilter.States.Any(y => y == x.State)).AsQueryable();
            }
            //3.city
            if (businessToBusinessFilter.Cities.Any())
            {
                b2bFilter = b2bFilter.Where(x => businessToBusinessFilter.Cities.Any(y => y == x.City)).AsQueryable();
            }
            //4.Area
            if (businessToBusinessFilter.Areas.Any())
            {
                b2bFilter = b2bFilter.Where(x => businessToBusinessFilter.Areas.Any(y => y == x.Area)).AsQueryable();
            }

            //5.Business Category
            if (businessToBusinessFilter.Areas.Any())
            {
                b2bFilter = b2bFilter.Where(x => businessToBusinessFilter.BusinessCategoryId.Any(y => y == x.CategoryId)).AsQueryable();
            }

            //6.Designation
            if (businessToBusinessFilter.Areas.Any())
            {
                b2bFilter = b2bFilter.Where(x => businessToBusinessFilter.Designation.Any(y => y == x.Designation)).AsQueryable();
            }

            //7.Tag
            var tags = _getBusinessToBusinessTags.Filter(businessToBusinessFilter.Tags).ToList();
            if (tags.Any())
            {
                b2bFilter = b2bFilter.Where(x => tags.Any(y => y == x.RequestId)).AsQueryable();
            }

            var b2bSearchResult = b2bFilter.Select(x => new BusinessToBusinesModel
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
            }).ToList();
            BusinessToBusinesListModel businessToBusinesListModel = new BusinessToBusinesListModel
            {
                BusinessToBusiness = b2bSearchResult,
                SearchCount = b2bSearchResult.Count(),
                Total = _customerDataManagementContext.BusinessToBusiness.Count()
            };

            return businessToBusinesListModel;
        }
    }
}