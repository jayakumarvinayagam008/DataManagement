namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class SaveDataModel
    {
        public int UploadTypeId { get; set; }
        public string FilePath { get; set; }
        public string Tags { get; set; }
        public string ClientFileName { get; set; }
    }
}