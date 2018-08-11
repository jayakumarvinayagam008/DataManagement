﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    class BusinessToBusinessUploadProcess : IUploadProcess
    {
        private readonly IBusinessToBusinessFileToDataModel _businessToBusinessFileToDataModel;
        private readonly ISaveBusinessToBusiness _saveBusinessToBusiness;

        public int UploadType { get { return 1; } }
        public BusinessToBusinessUploadProcess(IBusinessToBusinessFileToDataModel businessToBusinessFileToDataModel,
            ISaveBusinessToBusiness saveBusinessToBusiness)
        {
            _businessToBusinessFileToDataModel = businessToBusinessFileToDataModel;
            _saveBusinessToBusiness = saveBusinessToBusiness;
        }
        public UploadSaveStatus Upload(SaveDataModel saveDataModel)
        {
            var uploadStatus = new UploadSaveStatus();
            var customerData = _businessToBusinessFileToDataModel.ReadFileData(saveDataModel);
            uploadStatus.UploadedRows = customerData.Count(); // number of rows going to update
            var saveStatus = _saveBusinessToBusiness.Save(customerData);
            uploadStatus.IsUploaded = saveStatus;
            return uploadStatus;
        }
    }
}
