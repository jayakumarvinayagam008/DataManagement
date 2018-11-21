using Microsoft.AspNetCore.Mvc.Rendering;
using Persistance;
using System.Collections.Generic;
using System.Linq;
using Snickler.EFCore;
using Application.Common;

namespace Application.BusinessToCustomers.Queries
{
    public class GetBusinessToCustomerCity : IGetBusinessToCustomerCity
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessToCustomerCity(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }

        public IEnumerable<SelectListItem> Get()
        {
            IList<Role> roles;
            IList<TotalExperience> experence;
            IList<SearchCountry> country;
            IList<SearchState> state;
            IList<SearchCity> city;
            IList<SearchArea> area;
            IList<SearchSalary> salary;
            IList<SearchAge> age;
            IList<BToCTags> tags;
            
            _customerDataManagementContext.LoadStoredProc("dm.usp_B2CSearchBlock")               
               .ExecuteStoredProc((handler) =>
               {
                   roles = handler.ReadToList<Role>();
                   handler.NextResult();
                   experence = handler.ReadToList<TotalExperience>();
                   handler.NextResult();
                   country = handler.ReadToList<SearchCountry>();
                   handler.NextResult();
                   state = handler.ReadToList<SearchState>();
                   handler.NextResult();
                   city = handler.ReadToList<SearchCity>();
                   handler.NextResult();
                   area = handler.ReadToList<SearchArea>();
                   handler.NextResult();
                   age = handler.ReadToList<SearchAge>();
                   handler.NextResult();
                   salary = handler.ReadToList<SearchSalary>();
                   handler.NextResult();
                   tags = handler.ReadToList<BToCTags>();
               });

            var area1 = _customerDataManagementContext.BusinessToCustomer
                .Select(x => x.City.Trim())
                .Distinct<string>()
                .OrderBy(x => x).ToArray();

            return area1.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x =>
             new SelectListItem()
             {
                 Value = x,
                 Text = x
             }).AsEnumerable<SelectListItem>();
        }
    }
    
}
/*
	CREATE TABLE #tempArea(Area VARCHAR(500));
	CREATE TABLE #tempSalary(Salary VARCHAR(500));
	CREATE TABLE #tempAge(Age int);
     */
