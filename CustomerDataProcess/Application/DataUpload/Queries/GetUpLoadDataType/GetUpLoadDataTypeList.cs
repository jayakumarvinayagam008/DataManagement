using System.Collections.Generic;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public class GetUpLoadDataTypeList : IGetUpLoadDataTypeList
    {
        public IList<UploadDataType> Get()
        {
            return new List<UploadDataType> {
                new UploadDataType{ Id = 1, Name = "Business to Business" },
                new UploadDataType{ Id = 2, Name = "Business to Customers"},
                new UploadDataType{  Id=3, Name = "Customer Data"}
            };
        }
    }
}