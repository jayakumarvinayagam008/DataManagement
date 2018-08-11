using Application.Common;
using Application.DataUpload.Commands.SaveDataUpload;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Queries
{
    public class CustomerListDataModel
    {
        public DataFilter Filter { get; set; }
        public IEnumerable<CustomerDataModel> CustomerDataModels { get; set; }
        
    }
}
