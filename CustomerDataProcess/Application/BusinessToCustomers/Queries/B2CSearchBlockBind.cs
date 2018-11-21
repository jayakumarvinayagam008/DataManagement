using Application.Common;
using Persistance;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToCustomers.Queries
{
    public class B2CSearchBlockBind : IB2CSearchBlockBind
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public B2CSearchBlockBind(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public B2CSearchBlock Fetch()
        {
            B2CSearchBlock b2CSearchBlock = new B2CSearchBlock();
            _customerDataManagementContext.LoadStoredProc("dm.usp_B2CSearchBlock")
               .ExecuteStoredProc((handler) =>
               {
                   b2CSearchBlock.Roles = handler.ReadToList<Role>();
                   handler.NextResult();
                   b2CSearchBlock.Experience = handler.ReadToList<TotalExperience>();
                   handler.NextResult();
                   b2CSearchBlock.Country = handler.ReadToList<SearchCountry>();
                   handler.NextResult();
                   b2CSearchBlock.State = handler.ReadToList<SearchState>();
                   handler.NextResult();
                   b2CSearchBlock.City = handler.ReadToList<SearchCity>();
                   handler.NextResult();
                   b2CSearchBlock.Area = handler.ReadToList<SearchArea>();
                   handler.NextResult();
                   b2CSearchBlock.Age = handler.ReadToList<SearchAge>();
                   handler.NextResult();
                   b2CSearchBlock.Salary = handler.ReadToList<SearchSalary>();
                   handler.NextResult();
                   b2CSearchBlock.Tags = handler.ReadToList<BToCTags>();
               });
            return b2CSearchBlock;
        }
    }
}
