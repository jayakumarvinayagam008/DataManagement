using Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveCustomerDataTags : ISaveCustomerDataTags
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public SaveCustomerDataTags(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }
        public bool Save(int requestId, string[] tags)
        {
            IList<CustomerDataManagementTags> businessToBusinessTags = new List<CustomerDataManagementTags>();
            foreach (var item in tags)
            {
                businessToBusinessTags.Add(new CustomerDataManagementTags { RequestId = requestId, Tag = item });
            }
            _customerDataManagementContext.CustomerDataManagementTags.AddRange(businessToBusinessTags);
            return _customerDataManagementContext.SaveChanges() > 0;
        }
    }
}
