using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public class UploadData
    {
        public int UploadTypeId { get; set; }
        
        public IEnumerable<UploadDataType> UploadDataTypes { get; set; }
    }
}
