using System.Collections.Generic;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public class UploadData
    {
        public int UploadTypeId { get; set; }

        public IEnumerable<UploadDataType> UploadDataTypes { get; set; }
    }
}