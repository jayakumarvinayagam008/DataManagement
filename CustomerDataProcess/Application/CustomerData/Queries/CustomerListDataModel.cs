using Application.DataUpload.Commands.SaveDataUpload;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CustomerData.Queries
{
    public class CustomerListDataModel
    {
        public IEnumerable<CustomerDataModel> CustomerDataModels { get; set; }
        
    }
}
