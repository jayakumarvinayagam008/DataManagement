namespace Application.DataUpload.Commands.SaveDataUpload
{
    class BusinessToCustomerUploadProcess : IUploadProcess
    {
       

        public int UploadType { get { return 1; } }
        public BusinessToCustomerUploadProcess()
        {            
        }
        public UploadSaveStatus Upload(SaveDataModel saveDataModel)
        {
            var uploadStatus = new UploadSaveStatus();
            
            return uploadStatus;
        }
    }
}