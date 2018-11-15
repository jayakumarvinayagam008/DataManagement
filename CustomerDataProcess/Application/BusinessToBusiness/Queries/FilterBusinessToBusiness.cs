using Application.Common;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Linq;

namespace Application.BusinessToBusiness.Queries
{
    public class FilterBusinessToBusiness : IFilterBusinessToBusiness
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;
        private readonly IFilterBusinessToBusinessTags _getBusinessToBusinessTags;
        private readonly IGetBusinessCategory _getBusinessCategory;
        public FilterBusinessToBusiness(CustomerDataManagementContext customerDataManagementContext,
            IFilterBusinessToBusinessTags getBusinessToBusinessTags, IGetBusinessCategory getBusinessCategory)
        {
            _customerDataManagementContext = customerDataManagementContext;
            _getBusinessToBusinessTags = getBusinessToBusinessTags;
            _getBusinessCategory = getBusinessCategory;
        }

        public BusinessToBusinesListModel Search(BusinessToBusinessFilter businessToBusinessFilter)
        {           
            var country = string.Join(",", businessToBusinessFilter.Countries);
            var state = string.Join(",", businessToBusinessFilter.States);
            var city = string.Join(",", businessToBusinessFilter.Cities);
            var area = string.Join(",", businessToBusinessFilter.Areas);
            var designation = string.Join(",", businessToBusinessFilter.Designation);
            var categoryId = string.Join(",", businessToBusinessFilter.BusinessCategoryId);            
            var tags = string.Join(",", businessToBusinessFilter.Tags);
            var categories = _customerDataManagementContext.B2bcategory.ToList();

            var b2bFilter = _customerDataManagementContext.BusinessToBusiness
               .FromSql("EXECUTE dm.usp_SearchBusinessToBusiness @p0, @p1,@p2, @p3,@p4, @p5,@p6",
               parameters: new[] { country, state, city, area, designation, categoryId, tags }).ToList();

            var b2bSearchResult = b2bFilter.GroupJoin(categories,
               x => x.CategoryId,
               y => y.CategoryId,
                 (x, y) => new BusinessToBusinesModel
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
                     Web = x.Web,
                     CategoryName = y.Any() ? y.FirstOrDefault().Name : string.Empty
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