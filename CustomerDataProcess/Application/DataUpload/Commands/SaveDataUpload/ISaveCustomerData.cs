using System.Collections.Generic;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface ISaveCustomerData
    {
        bool Save(IEnumerable<CustomerDataModel> customerDataModels);
    }
}