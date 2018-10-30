using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public class GetCustomerRequestId : IGetLastCustomerRequestId
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetCustomerRequestId(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }
        public int LastRequestId()
        {
            var tags = _customerDataManagementContext.BusinessToCustomerTags.OrderByDescending(x => x.CreatedDate);
            if (tags != null && tags.Any())
                return tags.FirstOrDefault().RequestId.GetValueOrDefault();
            return 0; 
        }
    }
}
