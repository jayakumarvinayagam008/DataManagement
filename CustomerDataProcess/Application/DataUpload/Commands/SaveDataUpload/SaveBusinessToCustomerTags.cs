using Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveBusinessToCustomerTags : ISaveBusinessToCustomerTags
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public SaveBusinessToCustomerTags(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }
        public bool Save(int requestId, string[] tags)
        {
            IList<BusinessToCustomerTags> businessToBusinessTags = new List<BusinessToCustomerTags>();
            foreach (var item in tags)
            {
                businessToBusinessTags.Add(new BusinessToCustomerTags { RequestId = requestId, Tag = item });
            }
            _customerDataManagementContext.BusinessToCustomerTags.AddRange(businessToBusinessTags);
            return _customerDataManagementContext.SaveChanges() > 0;
        }
    }
}
