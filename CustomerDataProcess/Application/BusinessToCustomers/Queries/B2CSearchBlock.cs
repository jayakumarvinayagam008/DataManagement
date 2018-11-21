using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToCustomers.Queries
{
    public class B2CSearchBlock
    {
        public IList<Role> Roles { get; set; }
        public IList<TotalExperience> Experience { get; set; }
        public IList<SearchCountry> Country { get; set; }
        public IList<SearchState> State { get; set; }
        public IList<SearchCity> City { get; set; }
        public IList<SearchArea> Area { get; set; }
        public IList<SearchSalary> Salary { get; set; }
        public IList<SearchAge> Age { get; set; }
        public IList<BToCTags> Tags { get; set; }
        
    }

    
}
