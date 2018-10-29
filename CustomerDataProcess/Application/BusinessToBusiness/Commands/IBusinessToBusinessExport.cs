using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToBusiness.Commands
{
    public interface IBusinessToBusinessExport
    {
        string ExportExcel(IEnumerable<BusinessToBusinesModel> businessToBusinesModels, string fileRootPath, int rowRange);
    }
}
