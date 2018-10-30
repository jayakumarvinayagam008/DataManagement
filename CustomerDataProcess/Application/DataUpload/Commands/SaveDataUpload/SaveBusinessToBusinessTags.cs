using Persistance;
using System.Collections.Generic;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveBusinessToBusinessTags : ISaveBusinessToBusinessTags
    {
        private char expression = ',';
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public SaveBusinessToBusinessTags(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }
        public bool Save(int requestId, string[] tags)
        {
            IList<BusinessToBusinessTags> businessToBusinessTags = new List<BusinessToBusinessTags>();           
            foreach (var item in tags)
            {
                businessToBusinessTags.Add(new BusinessToBusinessTags { RequestId = requestId, Tag = item });
            }
            _customerDataManagementContext.BusinessToBusinessTags.AddRange(businessToBusinessTags);
            return _customerDataManagementContext.SaveChanges() > 0;
        }
    }
}
