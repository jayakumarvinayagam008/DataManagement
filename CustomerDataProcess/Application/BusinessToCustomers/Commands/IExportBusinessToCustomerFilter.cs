using Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.BusinessToCustomers.Commands
{
    public interface IExportBusinessToCustomerFilter
    {
        string CreateExcel(IEnumerable<BusinessToCustomerModel> businessToCustomerModels, string fileRootPath, int rowRange);
    }
}
