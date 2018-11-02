using System;
using System.Collections.Generic;

namespace Persistance
{
    public partial class UploadType
    {
        public UploadType()
        {
            UploadHistoryDetail = new HashSet<UploadHistoryDetail>();
        }

        public int UploadTypeId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<UploadHistoryDetail> UploadHistoryDetail { get; set; }
    }
}
