using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface IBusinessToBusinessFileToDataModel
    {
        (IEnumerable<BusinessToBusinesModel>, int) ReadFileData(SaveDataModel saveDataModel);
    }
}
