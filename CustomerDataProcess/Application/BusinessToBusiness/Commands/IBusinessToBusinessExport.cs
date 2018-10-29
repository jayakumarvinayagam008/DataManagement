using Application.Common;
using System.Collections.Generic;

namespace Application.BusinessToBusiness.Commands
{
    public interface IBusinessToBusinessExport
    {
        string ExportExcel(IEnumerable<BusinessToBusinesModel> businessToBusinesModels, string fileRootPath, int rowRange);
    }
}