﻿using System;
using System.Collections.Generic;

namespace Persistance
{
    public partial class UploadHistoryDetail
    {
        public int UploadId { get; set; }
        public string ClientFileName { get; set; }
        public string ServerFileName { get; set; }
        public string Path { get; set; }
        public int? StatusId { get; set; }
        public string Exception { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? UploadTypeId { get; set; }
        public int? RequestId { get; set; }
        public int? TotalRows { get; set; }
        public int? UpLoadedRows { get; set; }

        public UploadStatus Status { get; set; }
        public UploadType UploadType { get; set; }
    }
}
