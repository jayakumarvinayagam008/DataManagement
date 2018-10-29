using System.Collections.Generic;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public interface IGetUpLoadDataTypeList
    {
        IList<UploadDataType> Get();
    }
}