using Application.Common;
using Persistance;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Queries
{
    public class CustomerDataSearchBlockBind : ICustomerDataSearchBlockBind
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public CustomerDataSearchBlockBind(CustomerDataManagementContext dbContext)
        {
            _customerDataManagementContext = dbContext;
        }
        public CustomerDataSearchBlock Fetch()
        {
            CustomerDataSearchBlock customerDataSearchBlock = new CustomerDataSearchBlock();
            _customerDataManagementContext.LoadStoredProc("dm.usp_CDSearchBlock")
               .ExecuteStoredProc((handler) =>
               {                 
                   customerDataSearchBlock.Country = handler.ReadToList<SearchCountry>();
                   handler.NextResult();
                   customerDataSearchBlock.State = handler.ReadToList<SearchState>();
                   handler.NextResult();
                   customerDataSearchBlock.City = handler.ReadToList<SearchCity>();
                   handler.NextResult();
                   customerDataSearchBlock.Network = handler.ReadToList<SearchNetwork>();
                   handler.NextResult();
                   customerDataSearchBlock.BusinessVertical = handler.ReadToList<SearchBusinessVertical>();
                   handler.NextResult();
                   customerDataSearchBlock.CustomerName = handler.ReadToList<SearchCustomerName>();
                   handler.NextResult();
                   customerDataSearchBlock.DataQuality = handler.ReadToList<SearchDataQuality>();
                   handler.NextResult();
                   customerDataSearchBlock.Tags = handler.ReadToList<CustomerTags>();
               });
            return customerDataSearchBlock;
        }
    }
}
