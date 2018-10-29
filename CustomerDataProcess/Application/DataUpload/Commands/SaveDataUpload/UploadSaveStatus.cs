namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class UploadSaveStatus
    {
        public bool IsUploaded { get; set; }
        public string StatusMessage { get; set; }
        public int UploadedRows { get; set; }
        public int TotalRows { get; set; }
    }
}