namespace Application.DataUpload.Commands.SaveDataUpload
{
    public interface ISaveUploadDataCommand
    {
        UploadSaveStatus Upload(SaveDataModel saveDataModel);
    }
}