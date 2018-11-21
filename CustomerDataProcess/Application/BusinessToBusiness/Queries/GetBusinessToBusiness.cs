using Application.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Persistance;
using System.Linq;

namespace Application.BusinessToBusiness.Queries
{
    public class GetBusinessToBusiness : IGetBusinessToBusiness
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;      
        private readonly IGetBusinessCategory _getBusinessCategory;
        private readonly IGetBusinessToBusinessTags _getBusinessToBusinessTags;
        private readonly IB2BSearchBlockBind _b2BSearchBlockBind;
        public GetBusinessToBusiness(CustomerDataManagementContext dbContext,          
            IGetBusinessCategory getBusinessCategory, IGetBusinessToBusinessTags getBusinessToBusinessTags,
            IB2BSearchBlockBind b2BSearchBlockBind)
        {
            _customerDataManagementContext = dbContext;          
            _getBusinessCategory = getBusinessCategory;
            _getBusinessToBusinessTags = getBusinessToBusinessTags;
            _b2BSearchBlockBind = b2BSearchBlockBind;
        }

        public BusinessToBusinesListModel Get()
        {
            var searchBlock = _b2BSearchBlockBind.Fetch();                        

            var filterCity = searchBlock?.City.Select(x => new SelectListItem()
            {
                Value = x.City,
                Text = x.City
            }).AsEnumerable();
            var filterState = searchBlock?.State.Select(x => new SelectListItem()
            {
                Value = x.States,
                Text = x.States
            }).AsEnumerable(); 
            var filterArea = searchBlock?.Area.Select(x => new SelectListItem()
            {
                Value = x.Area,
                Text = x.Area
            }).AsEnumerable();
            var filterCountry = searchBlock?.Country.Select(x => new SelectListItem()
            {
                Value = x.Country,
                Text = x.Country
            }).AsEnumerable();
            var filterDestination = searchBlock?.Desigination.Select(x => new SelectListItem()
            {
                Value = x.Desigination,
                Text = x.Desigination
            }).AsEnumerable();
            var filterBusinesscategory = searchBlock?.BusinessCategory.Select(x => new SelectListItem()
            {
                Value = $"{x.CategoryId}",
                Text = x.Name
            }).AsEnumerable();
            var filterTags = JsonConvert.SerializeObject(searchBlock?.Tags);

            //var customer = _customerDataManagementContext.BusinessToBusiness.OrderByDescending(x => x.CreatedDate).Take(5000)
            //                                             .Select(cust =>
            //                                                          new BusinessToBusinesModel
            //                                                          {
            //                                                              Add1 = cust.Add1,
            //                                                              Add2 = cust.Add2,
            //                                                              Area = cust.Area,
            //                                                              CategoryId = cust.CategoryId,
            //                                                              CategoryName = cust.Category.Name,
            //                                                              City = cust.City,
            //                                                              CompanyName = cust.CompanyName,
            //                                                              ContactPerson = cust.ContactPerson,
            //                                                              Contactperson1 = cust.Contactperson1,
            //                                                              Designation = cust.Designation,
            //                                                              Designation1 = cust.Designation1,
            //                                                              Email = cust.Email,
            //                                                              Email1 = cust.Email1,
            //                                                              EstYear = cust.EstYear,
            //                                                              Fax = cust.Fax,
            //                                                              Id = cust.Id,
            //                                                              LandMark = cust.LandMark,
            //                                                              Mobile1 = cust.Mobile1,
            //                                                              MobileNew = cust.MobileNew,
            //                                                              Mobile2 = cust.Mobile2,
            //                                                              NoOfEmp = cust.NoOfEmp,
            //                                                              Phone1 = cust.Phone1,
            //                                                              Phone2 = cust.Phone2,
            //                                                              PhoneNew = cust.PhoneNew,
            //                                                              Pincode = cust.Pincode,
            //                                                              State = cust.State,
            //                                                              Web = cust.Web,
            //                                                              Country = cust.Country
            //                                                          }).AsEnumerable<BusinessToBusinesModel>();
            return new BusinessToBusinesListModel
            {              
                Filter = new DataFilter
                {
                    Area = filterArea,
                    Cities = filterCity,
                    Countries = filterCountry,
                    Desigination = filterDestination,
                    States = filterState,
                    BusinessCategories = filterBusinesscategory,
                    Tags = filterTags
                }
            };
        }
    }
}