using Application.Common;
using System.Collections.Generic;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface IBusinessToBusinessFileToDataModel
    {
        (IEnumerable<BusinessToBusinesModel>, int) ReadFileData(SaveDataModel saveDataModel);
    }
}