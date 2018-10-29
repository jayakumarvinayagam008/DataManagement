using Application.Common;
using System.Collections.Generic;

namespace Application.BusinessToBusiness.Queries
{
    public class BusinessToBusinesListModel
    {
        public DataFilter Filter { get; set; }
        public IEnumerable<BusinessToBusinesModel> BusinessToBusiness { get; set; }
        public int SearchCount { get; set; }
        public int Total { get; set; }
    }
}