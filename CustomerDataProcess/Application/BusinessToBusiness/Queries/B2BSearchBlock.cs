using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToBusiness.Queries
{
    public class B2BSearchBlock
    {       
        public IList<SearchCountry> Country { get; set; }
        public IList<SearchState> State { get; set; }
        public IList<SearchCity> City { get; set; }
        public IList<SearchArea> Area { get; set; }

        public IList<BusinessCategory> BusinessCategory { get; set; }
        public IList<SearchDesigination> Desigination { get; set; }
        public IList<BToBTags> Tags { get; set; }
    }
}
