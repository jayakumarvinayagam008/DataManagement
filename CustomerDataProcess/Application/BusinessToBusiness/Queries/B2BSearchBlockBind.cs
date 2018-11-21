using Application.Common;
using Persistance;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToBusiness.Queries
{
    public class B2BSearchBlockBind : IB2BSearchBlockBind
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public B2BSearchBlockBind(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        
        public B2BSearchBlock Fetch()
        {
            B2BSearchBlock b2BSearchBlock = new B2BSearchBlock();
            _customerDataManagementContext.LoadStoredProc("dm.usp_B2BSearchBlock")
               .ExecuteStoredProc((handler) =>
               {                  
                   b2BSearchBlock.Country = handler.ReadToList<SearchCountry>();
                   handler.NextResult(); 
                   b2BSearchBlock.State = handler.ReadToList<SearchState>();
                   handler.NextResult();
                   b2BSearchBlock.City = handler.ReadToList<SearchCity>();
                   handler.NextResult();
                   b2BSearchBlock.Area = handler.ReadToList<SearchArea>();
                   handler.NextResult();                 
                   b2BSearchBlock.BusinessCategory = handler.ReadToList<BusinessCategory>();
                   handler.NextResult();
                   b2BSearchBlock.Desigination = handler.ReadToList<SearchDesigination>();
                   handler.NextResult();
                   b2BSearchBlock.Tags = handler.ReadToList<BToBTags>();
               });
            return b2BSearchBlock;
        }
    }
}
