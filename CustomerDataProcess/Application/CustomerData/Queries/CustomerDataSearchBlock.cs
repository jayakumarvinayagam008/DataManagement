using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Queries
{
    public class CustomerDataSearchBlock
    {     
        public IList<SearchCountry> Country { get; set; }
        public IList<SearchState> State { get; set; }
        public IList<SearchCity> City { get; set; }
        public IList<SearchNetwork> Network { get; set; }
        public IList<SearchBusinessVertical> BusinessVertical { get; set; }
        public IList<SearchCustomerName> CustomerName { get; set; }
        public IList<SearchDataQuality> DataQuality { get; set; }
        public IList<CustomerTags> Tags { get; set; }
    }
}
