using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface ISaveCustomerData
    {
        bool Save(IEnumerable<CustomerDataModel> customerDataModels);
    }
}
