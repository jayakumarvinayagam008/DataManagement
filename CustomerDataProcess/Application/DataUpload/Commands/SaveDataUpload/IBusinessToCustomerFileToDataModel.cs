using Application.Common;
using System.Collections.Generic;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface IBusinessToCustomerFileToDataModel
    {
        (IEnumerable<BusinessToCustomerModel>, int) ReadFileData(SaveDataModel saveDataModel);
    }
}