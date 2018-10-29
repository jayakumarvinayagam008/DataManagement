using Application.NumberLookup.Command;
using Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.NumberLookup.Query
{
    public class GetNumberLoopUpData : IGetNumberLoopUpData
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetNumberLoopUpData(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }

        public IEnumerable<NumberLookUpDetail> FilterNumberLookUp(IEnumerable<Numbers> numberLookups)
        {
            var numbersDetail = numberLookups.GroupJoin(_customerDataManagementContext.NumberLookup,
                x => x.Series,
                y => y.Series,
                  (x, y) => new NumberLookUpDetail
                  {
                      Circle = y.Any() ? y.FirstOrDefault().Circle : string.Empty,
                      Operator = y.Any() ? y.FirstOrDefault().Operator : string.Empty,
                      Phone = x.PhoneNumber
                  }).ToList();
            return numbersDetail.AsEnumerable();
        }
    }
}