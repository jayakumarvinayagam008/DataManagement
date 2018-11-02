using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UploadSummary.Command
{
    public class SaveSummaryModel
    {
        public string ClientFileName { get; internal set; }
        public int? UploadTypeId { get; internal set; }
        public int? StatusId { get; internal set; }
        public string ServerFileName { get; internal set; }
        public int? RequestId { get; internal set; }
        public string Path { get; internal set; }
        public string UploadedBy { get; internal set; }
        public int UploadedRows { get; internal set; }
        public int TotalRows { get; internal set; }
        public bool SaveStatus { get; set; }
    }
}
