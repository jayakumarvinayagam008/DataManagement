using Application.DataUpload.Commands.SaveDataUpload;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Commands
{
    public interface IExportCustomerDataByExcel
    {
        string CreateExcel(IEnumerable<CustomerDataModel> customerDatas, string fileRootPath, int rowRange);
    }
}
