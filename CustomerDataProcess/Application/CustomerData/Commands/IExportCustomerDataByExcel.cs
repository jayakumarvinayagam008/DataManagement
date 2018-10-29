using Application.DataUpload.Commands.SaveDataUpload;
using System.Collections.Generic;

namespace Application.CustomerData.Commands
{
    public interface IExportCustomerDataByExcel
    {
        string CreateExcel(IEnumerable<CustomerDataModel> customerDatas, string fileRootPath, int rowRange);
    }
}