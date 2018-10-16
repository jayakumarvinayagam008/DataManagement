using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.NumberLookup.Command;
using Persistance;

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

          var numbersDetail =  _customerDataManagementContext.NumberLookup.Join(numberLookups, x => x.Series, y => y.Series,
                (x, y) => new NumberLookUpDetail
                {
                    Circle = x.Circle,
                    Operator = x.Operator,
                    Phone = y.PhoneNumber
                }).ToList();
            return numbersDetail.AsEnumerable();
        }
    }
}
