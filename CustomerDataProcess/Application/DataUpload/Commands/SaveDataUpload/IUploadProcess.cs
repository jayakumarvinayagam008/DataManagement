namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface IUploadProcess
    {
        int UploadType { get; }
        UploadSaveStatus Upload(SaveDataModel saveDataModel);
    }
}