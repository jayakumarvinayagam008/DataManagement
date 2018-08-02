using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Commands.SaveDataUpload
{
    public class UploadSaveStatus
    {
        public bool IsUploaded { get; set; }
        public string StatusMessage { get; set; }
        public int UploadedRows { get; set; }
    }
}
