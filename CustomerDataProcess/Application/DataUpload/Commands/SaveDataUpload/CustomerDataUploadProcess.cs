using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    class CustomerDataUploadProcess : IUploadProcess
    {
        private readonly IFileToDataModel _fileToDataModel;
        private readonly ISaveCustomerData _saveCustomerData;

        public int UploadType { get { return 3; } }
        public CustomerDataUploadProcess(IFileToDataModel fileToDataModel,
            ISaveCustomerData saveCustomerData)
        {
            _fileToDataModel = fileToDataModel;
            _saveCustomerData = saveCustomerData;
        }
        public UploadSaveStatus Upload(SaveDataModel saveDataModel)
        {
            var uploadStatus = new UploadSaveStatus();
            var customerData = _fileToDataModel.ReadFileData(saveDataModel);
            uploadStatus.UploadedRows = customerData.Count(); // number of rows going to update
            var saveStatus = _saveCustomerData.Save(customerData);
            uploadStatus.IsUploaded = saveStatus;
            return uploadStatus;
        }
    }
}
