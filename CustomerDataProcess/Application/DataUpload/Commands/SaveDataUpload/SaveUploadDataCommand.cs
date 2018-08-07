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
        private readonly IBusinessToBusinessFileToDataModel _businessToBusinessFileToDataModel;
        private readonly IBusinessToCustomerFileToDataModel _businessToCustomerFileToDataModel;
        public SaveUploadDataCommand(IFileToDataModel fileToDataModel, ISaveCustomerData saveCustomerData,
            IBusinessToBusinessFileToDataModel businessToBusinessFileToDataModel, IBusinessToCustomerFileToDataModel businessToCustomerFileToDataModel)
        {
            _fileToDataModel = fileToDataModel;
            _saveCustomerData = saveCustomerData;
            _businessToBusinessFileToDataModel = businessToBusinessFileToDataModel;
            _businessToCustomerFileToDataModel = businessToCustomerFileToDataModel;
        }
       
        public UploadSaveStatus Upload(SaveDataModel saveDataModel)
        {
            var uploadStatus = new UploadSaveStatus();
            if(saveDataModel.UploadTypeId == (int)UploadType.BusinessToBusiness)
            {
                var businessToBusiness = _businessToBusinessFileToDataModel.ReadFileData(saveDataModel);
                uploadStatus.UploadedRows = businessToBusiness.Count(); // number of rows going to update

            }
            else if(saveDataModel.UploadTypeId == (int)UploadType.BusinessToCustomer)
            {
                var businessToCustomer = _businessToCustomerFileToDataModel.ReadFileData(saveDataModel);
                uploadStatus.UploadedRows = businessToCustomer.Count(); // number of rows going to update
            }
            else if(saveDataModel.UploadTypeId == (int)UploadType.CustomerData)
            {
                var customerData = _fileToDataModel.ReadFileData(saveDataModel);
                uploadStatus.UploadedRows = customerData.Count(); // number of rows going to update
                var saveStatus = _saveCustomerData.Save(customerData);
                uploadStatus.IsUploaded = saveStatus;
            }            
            return uploadStatus;
        }
    }
}
