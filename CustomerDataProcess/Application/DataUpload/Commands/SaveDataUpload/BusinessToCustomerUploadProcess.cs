using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    //class BusinessToCustomerUploadProcess : IUploadProcess
    //{
    //    private readonly IBusinessToCustomerFileToDataModel _businessToCustomerFileToDataModel;
    //    private readonly ISaveBusinessToCustomer _saveCustomerData;

    //    public int UploadType { get { return 3; } }
    //    public BusinessToCustomerUploadProcess(IBusinessToCustomerFileToDataModel businessToCustomerFileToDataModel,
    //        ISaveBusinessToCustomer saveCustomerData)
    //    {
    //        _businessToCustomerFileToDataModel = businessToCustomerFileToDataModel;
    //        _saveCustomerData = saveCustomerData;
    //    }
    //    public UploadSaveStatus Upload(SaveDataModel saveDataModel)
    //    {
    //        var uploadStatus = new UploadSaveStatus();
    //        var customerDataProcess = _businessToCustomerFileToDataModel.ReadFileData(saveDataModel);
    //        var customerData = customerDataProcess.Item1;
    //        uploadStatus.TotalRows = customerDataProcess.Item2;
    //        uploadStatus.UploadedRows = customerData.Count(); // number of rows going to update
    //        var saveStatus = _saveCustomerData.Save(customerData);
    //        uploadStatus.IsUploaded = saveStatus;
    //        return uploadStatus;
    //    }
    //}
}
