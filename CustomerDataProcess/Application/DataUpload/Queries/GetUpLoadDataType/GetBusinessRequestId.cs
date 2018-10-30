using Persistance;
using System.Linq;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public class GetBusinessRequestId : IGetLastBusinessRequestId
    {
        private readonly CustomerDataManagementContext _customerDataManagementContext;

        public GetBusinessRequestId(CustomerDataManagementContext customerDataManagementContext)
        {
            _customerDataManagementContext = customerDataManagementContext;
        }
        public int LastRequestId()
        {
            var tags = _customerDataManagementContext.BusinessToBusinessTags.OrderByDescending(x => x.CreatedDate);
            if(tags != null && tags.Any())
                return tags.FirstOrDefault().RequestId.GetValueOrDefault();
            return 0;
        }
    }
}
