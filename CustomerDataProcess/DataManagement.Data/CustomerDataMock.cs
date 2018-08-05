using System;
using System.Collections.Generic;

namespace DataManagement.Data
{
    public class CustomerDataMock
    {
        public IEnumerable<CustomerDataDb> CustomerDataDbs;
        public CustomerDataMock()
        {
            CustomerDataDbs = new List<CustomerDataDb>() { 
            
            
            };
        }
    }
}
