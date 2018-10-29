using System;
using System.Collections.Generic;

namespace Persistance
{
    public partial class UploadStatus
    {
        public UploadStatus()
        {
            UploadHistoryDetail = new HashSet<UploadHistoryDetail>();
        }

        public int StatusId { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string FileName { get; set; }

        public ICollection<UploadHistoryDetail> UploadHistoryDetail { get; set; }
    }
}
