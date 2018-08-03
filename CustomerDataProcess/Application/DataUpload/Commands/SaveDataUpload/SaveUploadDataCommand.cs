using Application.Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveUploadDataCommand : ISaveUploadDataCommand
    {
        private readonly IFileToDataModel _fileToDataModel;
        private readonly ISaveCustomerData _saveCustomerData;
        public SaveUploadDataCommand(IFileToDataModel fileToDataModel, ISaveCustomerData saveCustomerData)
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
