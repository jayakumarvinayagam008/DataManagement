using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UploadSummary.Quires
{
    public class UploadSummary
    {
        public int RequestId { get; set; }
        public string UploadType { get; set; }
        public string ClientFileName { get; set; }
        public string ServerName { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedOn { get; set; }
        public int RequestedRows { get; set; }
        public int UploadedRows { get; set; }
    }
}
