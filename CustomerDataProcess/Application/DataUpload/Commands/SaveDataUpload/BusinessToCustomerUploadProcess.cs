using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    class BusinessToCustomerUploadProcess : IUploadProcess
    {
        private readonly IBusinessToCustomerFileToDataModel _businessToCustomerFileToDataModel;
        private readonly ISaveCustomerData _saveCustomerData;

        public int UploadType { get { return 3; } }
        public BusinessToCustomerUploadProcess(IBusinessToCustomerFileToDataModel businessToCustomerFileToDataModel,
            ISaveCustomerData saveCustomerData)
        {
            _businessToCustomerFileToDataModel = businessToCustomerFileToDataModel;
            _saveCustomerData = saveCustomerData;
        }
        public UploadSaveStatus Upload(SaveDataModel saveDataModel)
        {
            var uploadStatus = new UploadSaveStatus();
            var customerData = _businessToCustomerFileToDataModel.ReadFileData(saveDataModel);
            uploadStatus.UploadedRows = customerData.Count(); // number of rows going to update
            //var saveStatus = _saveCustomerData.Save(customerData);
            //uploadStatus.IsUploaded = saveStatus;
            return uploadStatus;
        }
    }
}
