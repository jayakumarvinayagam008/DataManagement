using Application.Common;
using System.Collections.Generic;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface ISaveBusinessToCustomer
    {
        bool Save(IEnumerable<BusinessToCustomerModel> businessToCustomer, int requestId);
    }
}