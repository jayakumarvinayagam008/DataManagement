namespace Application.DataUpload.Commands.SaveDataUpload
{
    //class CustomerDataUploadProcess : IUploadProcess
    //{
    //    private readonly IFileToDataModel _fileToDataModel;
    //    private readonly ISaveCustomerData _saveCustomerData;

    //    public int UploadType { get { return 3; } }
    //    public CustomerDataUploadProcess(IFileToDataModel fileToDataModel,
    //        ISaveCustomerData saveCustomerData)
    //    {
    //        _fileToDataModel = fileToDataModel;
    //        _saveCustomerData = saveCustomerData;
    //    }
    //    public UploadSaveStatus Upload(SaveDataModel saveDataModel)
    //    {
    //        var uploadStatus = new UploadSaveStatus();
    //        var customerData = _fileToDataModel.ReadFileData(saveDataModel);
    //        uploadStatus.UploadedRows = customerData.Item1.Count(); // number of rows going to update
    //        var saveStatus = _saveCustomerData.Save(customerData.Item1);
    //        uploadStatus.IsUploaded = saveStatus;
    //        uploadStatus.TotalRows = customerData.Item2;
    //        return uploadStatus;
    //    }
    //}
}