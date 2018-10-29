using System.Collections.Generic;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface IFileToDataModel
    {
        (IEnumerable<CustomerDataModel>, int) ReadFileData(SaveDataModel saveDataModel);
    }
}