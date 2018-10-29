using Application.Common;
using System.Collections.Generic;

namespace Application.BusinessToCustomers.Commands
{
    public interface IExportBusinessToCustomerFilter
    {
        string CreateExcel(IEnumerable<BusinessToCustomerModel> businessToCustomerModels, string fileRootPath, int rowRange);
    }
}