using Application.Common;

namespace Application.DataUpload.Queries.GetUpLoadDataType
{
    public class GetFileName : IGetFileName
    {
        public string Get(int typeId) => UploadFileSource.GetFileName(typeId);
    }
}