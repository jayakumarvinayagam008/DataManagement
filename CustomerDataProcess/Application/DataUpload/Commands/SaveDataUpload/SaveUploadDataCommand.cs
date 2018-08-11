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
        private readonly ISaveBusinessToBusiness _saveBusinessToBusiness;
        private readonly IValidateEntiry _validateEntiry;
        private readonly IValidateBusinessCategoruEntiry _validateBusinessCategoruEntiry;
        private readonly ISaveBusinessToCustomer _saveBusinessToCustomer;
        //private IUploadProcess[] uploadProcesses = new IUploadProcess[] {
        //    new BusinessToCustomerUploadProcess(new BusinessToCustomerFileToDataModel(), new SaveCustomerData()),

        //};
        public SaveUploadDataCommand(IFileToDataModel fileToDataModel, ISaveCustomerData saveCustomerData,
            IBusinessToBusinessFileToDataModel businessToBusinessFileToDataModel, IBusinessToCustomerFileToDataModel businessToCustomerFileToDataModel,
            ISaveBusinessToBusiness saveBusinessToBusiness, IValidateEntiry validateEntiry,
            IValidateBusinessCategoruEntiry validateBusinessCategoruEntiry,
            ISaveBusinessToCustomer saveBusinessToCustomer)
        {
            _fileToDataModel = fileToDataModel;
            _saveCustomerData = saveCustomerData;
            _businessToBusinessFileToDataModel = businessToBusinessFileToDataModel;
            _businessToCustomerFileToDataModel = businessToCustomerFileToDataModel;
            _saveBusinessToBusiness = saveBusinessToBusiness;
            _validateEntiry = validateEntiry;
            _validateBusinessCategoruEntiry = validateBusinessCategoruEntiry;
            _saveBusinessToCustomer = saveBusinessToCustomer;
        }
       
        public UploadSaveStatus Upload(SaveDataModel saveDataModel)
        {
            var uploadStatus = new UploadSaveStatus();
            if(saveDataModel.UploadTypeId == (int)UploadType.BusinessToBusiness)
            {
                var businessToBusiness = _businessToBusinessFileToDataModel.ReadFileData(saveDataModel);
                uploadStatus.UploadedRows = businessToBusiness.Count(); // number of rows going to update
                // Check business category validation
                // Ceck phone number validation 
                var phone = businessToBusiness.Select(x => x.Phone1).AsEnumerable<string>();
                if (true || _validateEntiry.Validate(phone).Count() == uploadStatus.UploadedRows)
                {
                    var categoryName = businessToBusiness.Select(x => x.CategoryId.Value).AsEnumerable<int>();
                    var unmappedCategory = _validateBusinessCategoruEntiry.Validate(categoryName).ToList<int>();
                    var validBusinessToBusiness = businessToBusiness.Where(x =>
                                                    !unmappedCategory.Any(y => y == x.CategoryId)).AsEnumerable<BusinessToBusinesModel>();
                    if (true || unmappedCategory.Count()<1)
                    {
                        var status = _saveBusinessToBusiness.Save(validBusinessToBusiness);
                    }else
                    {
                        uploadStatus.StatusMessage = "Some business category doesn't mapped.";
                    }
                }else
                {
                    uploadStatus.StatusMessage = "Phone number dublicate";
                }
            }
            else if(saveDataModel.UploadTypeId == (int)UploadType.BusinessToCustomer)
            {
                var businessToCustomer = _businessToCustomerFileToDataModel.ReadFileData(saveDataModel);
                uploadStatus.UploadedRows = businessToCustomer.Count(); // number of rows going to update
                var saveStatus = _saveBusinessToCustomer.Save(businessToCustomer);
                uploadStatus.IsUploaded = saveStatus;
            }
            else if(saveDataModel.UploadTypeId == (int)UploadType.CustomerData)
            {
                var customerData = _fileToDataModel.ReadFileData(saveDataModel);
                uploadStatus.UploadedRows = customerData.Count(); // number of rows going to update
                var saveStatus = _saveCustomerData.Save(customerData);
                uploadStatus.IsUploaded = saveStatus;
            } else
            {
                uploadStatus.IsUploaded = false;
                uploadStatus.StatusMessage = "Please upload valid file";
            }
            return uploadStatus;
        }
    }
}
