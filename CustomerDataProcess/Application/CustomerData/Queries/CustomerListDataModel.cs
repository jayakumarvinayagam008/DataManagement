using Application.Common;
using Application.DataUpload.Commands.SaveDataUpload;
using System.Collections.Generic;

namespace Application.CustomerData.Queries
{
    public class CustomerListDataModel
    {
        public DataFilter Filter { get; set; }
        public IEnumerable<CustomerDataModel> CustomerDataModels { get; set; }
        public int SearchCount { get; set; }
        public int Total { get; set; }
    }
}